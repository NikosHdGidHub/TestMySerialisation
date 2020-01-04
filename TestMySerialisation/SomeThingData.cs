using System;
using System.Collections.Generic;
using TestMySerialisation.Attributes;
namespace TestMySerialisation
{
	[SerialisationClass]
	public struct LikeFood
	{
		public string Name { get; set; }
		public string Category { get; set; }
	}
	[SerialisationClass]
	public class User
	{
		protected int secretKey;
		public int Age { get; set; }
		public string Name { get; set; }
		public List<User> Children { get; } = new List<User>();
		public List<LikeFood> LikeFoods { get; } = new List<LikeFood>();
		public void SetKey(int key)
		{
			secretKey = key + 1;
		}
	}
	[SerialisationClass]
	public class FullUser : User
	{
		private readonly string myDocs = "Docs";
		public string MyBusiness { get; set; }
		public string GetDocs(int key)
		{
			if (key == secretKey)
			{
				return myDocs;
			}
			else return Guid.NewGuid().ToString();
		}
	}
}
