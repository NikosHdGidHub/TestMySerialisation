using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestMySerialisation
{
	class Program
	{
		static void Main(string[] args)
		{
			#region Подготовка данных
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


			var maxSize = int.Parse("fff", System.Globalization.NumberStyles.HexNumber);
			Console.WriteLine(maxSize);
			Console.WriteLine(fullUser.GetDocs(1001));
			#endregion


			Ser(object data)



			Console.ReadLine();
		}

	}

	class MySerialization
	{
		public void Ser(Stream stream,object data)
		{
			//stream.R
		}
		public object Deser(Stream stream)
		{
			throw new NotImplementedException();
		}
	}
}
