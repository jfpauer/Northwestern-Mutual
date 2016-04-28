using ClassLibrary1.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace ClassLibrary1
{

    public class WebApplication1ServiceFacade : IWebApplication1ServiceFacade
    {
        #region Names
        private static List<string> PackerNames = new List<string>()
    {
"Abbrederis, Jared          ",
"Adams, Davante             ",
"Backman, Kennard           ",
"Bakhtiari, David           ",
"Banjo, Chris               ",
"Barclay, Don               ",
"Barrington, Sam            ",
"Boyd, Josh                 ",
"Bradford, Carl             ",
"Bulaga, Bryan              ",
"Burnett, Morgan            ",
"Campbell, William          ",
"Clinton-Dix, Ha Ha         ",
"Cobb, Randall              ",
"Crockett, John             ",
"Crosby, Mason              ",
"Daniel, Robertson          ",
"Daniels, Mike              ",
"Drew, Ray                  ",
"Elliott, Jayrone           ",
"Goodson, Demetri           ",
"Guion, Letroy              ",
"Gunter, LaDarius           ",
"Henry, Mitchell            ",
"Hundley, Brett             ",
"Hyde, Micah                ",
"Janis, Jeff                ",
"Johnson, Jamel             ",
"Jones, Datone              ",
"Kowalski, Vince            ",
"Lacy, Eddie                ",
"Lang, T.J.                 ",
"Linsley, Corey             ",
"Lovato, Rick               ",
"Masthay, Tim               ",
"Matthews, Clay             ",
"McBryde, B.J.              ",
"McCray, Lerentee           ",
"Montgomery, Ty             ",
"Nelson, Jordy              ",
"Pennel, Mike               ",
"Peppers, Julius            ",
"Perillo, Justin            ",
"Perry, Nick                ",
"Randall, Damarious         ",
"Ringo, Christian           ",
"Ripkowski, Aaron           ",
"Rodgers, Aaron             ",
"Rodgers, Richard           ",
"Rollins, Quinten           ",
"Rotheram, Matt             ",
"Ryan, Jake                 ",
"Shields, Sam               ",
"Sitton, Josh               ",
"Starks, James              ",
"Taylor, Lane               ",
"Thomas, Joe                ",
"Tretter, JC                ",
"Vujnovich, Jeremy          ",
"Walker, Josh               ",
"Williams, Ed               ",
"Williams, Ryan             ",
"Goode, Brett               ",
"Jones, James               ",
"Kuhn, John                 ",
"Neal, Mike                 ",
"Quarless, Andrew           ",
"Richardson, Sean           "

    };
        #endregion
        #region Numbers
        private static List<int> PackersNumber = new List<int>()
        {
84,
17,
86,
69,
32,
67,
58,
93,
54,
75,
42,
62,
21,
18,
38,
2 ,
31,
76,
94,
91,
39,
98,
36,
85,
7 ,
33,
83,
10,
95,
50,
27,
70,
63,
59,
8 ,
52,
77,
55,
88,
87,
64,
56,
80,
53,
23,
97,
22,
12,
82,
24,
74,
47,
37,
71,
44,
65,
48,
73,
60,
79,
19,
9 ,
61,
89,
30,
96,
81,
28
        };
        #endregion

        public List<PackersPlayer> GetPackers(string searchInput)
        {
            try
            {
                var searchWords = searchInput.Split(new char[0], StringSplitOptions.RemoveEmptyEntries);
                List<PackersPlayer> packerPlayers = new List<PackersPlayer>();
                foreach (var s in searchWords)
                {
                    int value;
                    if (int.TryParse(s, out value))
                    {
                        var getPlayersByNumber = GetPackersByNumber(value);
                        if (getPlayersByNumber == null) { continue; }
                        AddPlayerIfNotExist(ref packerPlayers, getPlayersByNumber);
                    }
                    else
                    {
                        var getPlayersByName = GetPackersByName(s);
                        if (getPlayersByName == null) { continue; }
                        AddPlayerIfNotExist(ref packerPlayers, getPlayersByName);
                    }
                }
                return packerPlayers;
            }
            catch
            {
                Debug.WriteLine("Error in GetPackerByName method.");
                return new List<PackersPlayer>();
            }
        }

        private void AddPlayerIfNotExist(ref List<PackersPlayer> playerList, List<PackersPlayer> playersToAdd)
        {
            foreach (var player in playersToAdd)
            {
                var playerExists = playerList.Where(p => player.Number.Equals(p.Number) && player.Name.Equals(p.Name)).ToList().Any();
                if (!playerExists) { playerList.Add(player); }
            }
        }

        private List<PackersPlayer> GetPackersByName(string s)
        {
            var packerNames = PackerNames.Where(n => n.ToLower().Contains(s.ToLower())).ToList();

            if (packerNames == null) { return new List<PackersPlayer>(); }

            List<PackersPlayer> players = new List<PackersPlayer>();
            foreach (var name in packerNames)
            {
                int indexOfNumber = PackerNames.IndexOf(name);

                if (indexOfNumber > PackersNumber.Count - 1) { continue; }

                PackersPlayer player = new PackersPlayer()
                {
                    Name = name,
                    Number = PackersNumber[indexOfNumber].ToString(),
                };
                players.Add(player);
            }
            return players;
        }

        private List<PackersPlayer> GetPackersByNumber(int s)
        {
            if (s == 0) { return new List<PackersPlayer>(); }

            var packersNumbers = PackersNumber.Where(n => n == s).ToList();

            if (packersNumbers == null || !packersNumbers.Any()) { return new List<PackersPlayer>(); }

            List<PackersPlayer> players = new List<PackersPlayer>();
            foreach (var number in packersNumbers)
            {
                int indexOfNumber = PackersNumber.IndexOf(number);

                if (indexOfNumber > PackerNames.Count - 1) { return null; }

                PackersPlayer player = new PackersPlayer()
                {
                    Name = PackerNames[indexOfNumber],
                    Number = number.ToString(),
                };
                players.Add(player);
            }
            return players;
        }

    }
}
