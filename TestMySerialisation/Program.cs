using System;
using System.Collections.Generic;
using System.Linq;

namespace TestMySerialisation
{
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


			var maxSize = int.Parse("fff", System.Globalization.NumberStyles.HexNumber);
			Console.WriteLine(maxSize);
			Console.WriteLine(fullUser.GetDocs(1001));
			#endregion

			var testArr = new[] { 1, 2, 3, 4, 5 };
			var testList = new List<int> { 1, 2, 3, 4, 5 };

			var s = new MySerialization();

			Console.WriteLine();
			Console.WriteLine();
			Console.WriteLine();
			Console.WriteLine();
			Console.WriteLine("userExemplar");
			Console.WriteLine(s.SerToString(user));
			Console.WriteLine("FulluserExemplar");
			Console.WriteLine(s.SerToString(fullUser));
			Console.WriteLine("testArr");
			Console.WriteLine(s.SerToString(testArr));
			Console.WriteLine("testList");
			Console.WriteLine(s.SerToString(testList));
			Console.WriteLine("12 - num int");
			Console.WriteLine(s.SerToString(12));
			Console.WriteLine("1 - char");
			Console.WriteLine(s.SerToString('1'));
			Console.WriteLine("123 - string");
			Console.WriteLine(s.SerToString("123"));
			Console.WriteLine("foodTest - Struct Exemplar");
			Console.WriteLine(s.SerToString(foodTest));






			Console.ReadLine();
		}

	}

	internal class MySerialization
	{
		public string SerToString(object data)
		{
			var type = data.GetType();
			Console.WriteLine(data + " < ToString");
			Console.WriteLine(type.Name + " < Name");
			Console.WriteLine(type.FullName + " < FullName");
			Console.WriteLine(type.IsClass + " < IsClass");
			Console.WriteLine(type.IsValueType + " < IsValueType");
			Console.WriteLine(type.IsGenericType + " < IsGenericType");
			Console.WriteLine(type.IsArray + " < IsArray");
			Console.WriteLine(type.IsNotPublic + " < IsNotPublic");
			Console.WriteLine(type.IsPublic + " < IsPublic");
			Console.Write("Get Attribute: ");
			var attr = type.CustomAttributes.FirstOrDefault(a => a.AttributeType.Name == "SerialisationClassAttribute");
			Console.WriteLine(attr != null);

			//TODO: Определить является значение классом/структурой или списком/массивом или заглушкой (итоговое значение)



			return null;
		}
		public object Deser()
		{
			throw new NotImplementedException();
		}
	}
}
