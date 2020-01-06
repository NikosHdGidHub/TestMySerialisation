using System;
using System.Collections.Generic;
using System.Globalization;
using Lib.MySerialisation;


namespace TestMySerialisation
{
	internal class someClass
	{
		public string Name { get; set; }
	}

	internal struct someStruct
	{
		public string Name { get; set; }
	}
	internal class Program
	{
		private static void Main(string[] args)
		{
			#region Подготовка данных
			var foodTest = new LikeFood { Name = "Test" };
			var user = new User { Name = "User", Age = 39 };
			var fullUser = new FullUser { Name = "FullUser", Age = 40 };
			for (int i = 0; i < 10; i++)
			{
				var food = new LikeFood { Name = "Food " + i, Category = "Category " + i };
				var child = new User { Name = "Child " + i, Age = 10 + i };
				user.Children.Add(child);
				user.LikeFoods.Add(food);
				fullUser.Children.Add(child);
				fullUser.LikeFoods.Add(food);
			}
			fullUser.SetKey(1000);


			var testArr = new[] { 1, 2, 3, 4, 5 };
			var testList = new List<int> { 1, 2, 3, 4, 5 };
			var someClass = new someClass();
			var someStruct = new someStruct();


			var maxSize = int.Parse("fff", NumberStyles.HexNumber);
			Console.WriteLine(maxSize);
			Console.WriteLine(fullUser.GetDocs(1001));
			#endregion



			var serialisation = new MySerialization();

			Console.WriteLine();
			Console.WriteLine();
			Console.WriteLine();
			Console.WriteLine();
			Console.WriteLine("UserExemplar");
			Console.WriteLine(serialisation.SerToString(user));
			Console.WriteLine("FullUserExemplar");
			Console.WriteLine(serialisation.SerToString(fullUser));
			Console.WriteLine("testArr");
			Console.WriteLine(serialisation.SerToString(testArr));
			Console.WriteLine("testList");
			Console.WriteLine(serialisation.SerToString(testList));
			Console.WriteLine("12 - num int");
			Console.WriteLine(serialisation.SerToString(12));
			Console.WriteLine("1 - char");
			Console.WriteLine(serialisation.SerToString('1'));
			Console.WriteLine("123 - string");
			Console.WriteLine(serialisation.SerToString("123"));
			Console.WriteLine("foodTest - Struct Exemplar");
			Console.WriteLine(serialisation.SerToString(foodTest));

			Console.WriteLine("someClass - not serializable class");
			Console.WriteLine(serialisation.SerToString(someClass));
			Console.WriteLine("someStruct - not serializable struct");
			Console.WriteLine(serialisation.SerToString(someStruct));


			string lenData;
			string result;
			lenData = serialisation.ObjectHandler("123456789023 sdf sdf f2333ds fs sdf22323233131213 dfd fds 1234567890123456", out result);
			lenData = serialisation.ObjectHandler(5670125345670123456, out  result);
			lenData = serialisation.ObjectHandler(434645435, out  result);


			Console.ReadLine();
		}

	}

	
}
