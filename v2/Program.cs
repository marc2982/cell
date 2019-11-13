﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cell.Bots;
using Newtonsoft.Json;

namespace Cell
{
	class Program
	{
		static void Main(string[] args)
		{
			string _filePath = Directory.GetParent(Directory.GetParent(System.IO.Path.GetDirectoryName(System.AppDomain.CurrentDomain.BaseDirectory)).FullName).FullName;
			var forts = new List<Fort>();
			forts.Add(new Fort { BirthSpeed = 10, ID = 1, FortOwner = "p1", NumDefendingGuys = 10, Location = new Point { X = 1, Y = 1 } });
			//forts.Add(new Fort { BirthSpeed = 10, ID = 1, FortOwner = null, NumDefendingGuys = 10, Location = new Point { X = 1, Y = 8 } });
			forts.Add(new Fort { BirthSpeed = 0, ID = 2, FortOwner = "p2", NumDefendingGuys = 0, Location = new Point { X = 8, Y = 8 } });
			var jsonForts = JsonConvert.SerializeObject(forts);

			var thing1 = new Dictionary<string, IBot>();
			var bot1 = new Bot1();
			bot1.SetPlayer("p1");

			var bot2 = new Bot1();
			bot2.SetPlayer("p2");

			thing1.Add("p1", bot1);
			thing1.Add("p2", bot2);

			var gameState = new StringBuilder();
			var cellGame = new Cell();
			var winner = cellGame.PlayGame(jsonForts, thing1, gameState);

			Console.WriteLine(gameState);
			Console.WriteLine($"Winner: {winner}");
			var test = _filePath + Path.Combine(@"\Results\", DateTime.UtcNow.ToFileTime().ToString()) + ".txt";
			System.IO.File.WriteAllText(test, gameState.ToString());
			Console.ReadLine();
		}
	}
}
