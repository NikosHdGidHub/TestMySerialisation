using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestMySerialisation.Attributes;
namespace TestMySerialisation
{
	[SerialisationClass]
	struct LikeFood
	{
		public string Name { get; set; }
		public string Category { get; set; }
	}
	[SerialisationClass]
	class User
	{
		protected int secretKey;
		public int Age { get; set; }
		public string Name { get; set; }
		public List<User> Children { get; } = new List<User>();
		public List<LikeFood> LikeFoods { get; } = new List<LikeFood>();
		public void SetKey (int key)
		{
			secretKey = key + 1;
		}
	}
	[SerialisationClass]
	class FullUser : User
	{
		private string myDocs = "Docs";
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
