using System;
using System.Linq;

namespace Lib.MySerialisation
{
	public class MySerialization
	{
		private string PrimitiveHandler(string str, out string result)
		{
			result = str;
			var strLenText = str.Length.ToString("X");
			var strLenTextLen = strLenText.Length;
			if (strLenTextLen > 3) throw new FormatException(nameof(str));

			if (strLenTextLen == 3) return strLenText;
			if (strLenTextLen == 2) return "0" + strLenText;
			return "00" + strLenText ?? "0";
		}
		private string PrimitiveHandler(object data, out string result)
		{
			return PrimitiveHandler(data.ToString(), out result);
		}
		/// <summary>
		/// 
		/// </summary>
		/// <param name="data"></param>
		/// <param name="result">Собщение</param>
		/// <returns>длину сообщения</returns>
		public string ObjectHandler(object data, out string result)
		{
			result = "";
			if (data == null) return "nll";
			if (data.GetType().IsPrimitive)
			{
				return PrimitiveHandler(data, out result);
			}

			if (data is string newStr)
			{
				return PrimitiveHandler(newStr, out result);
			}
			if (data.GetType().IsArray)
			{
				var array = data;
			}
			return default;
		}
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
			Console.Write("Get Attribute: ");
			var attr = type.CustomAttributes.FirstOrDefault(a => a.AttributeType.Name == "SerialisationClassAttribute");
			Console.WriteLine(attr != null);

			//TODO: Определить является значение классом/структурой или списком или массивом или заглушкой (итоговое значение)
			Console.WriteLine("Определение: ");
			if (attr != null)
			{
				Console.WriteLine("наше творение(класс структура");
			}
			else
			{
				Console.WriteLine("массив либо лист либо заглушка");
			}

			return null;
		}
		public object Deser()
		{
			throw new NotImplementedException();
		}
	}
}
