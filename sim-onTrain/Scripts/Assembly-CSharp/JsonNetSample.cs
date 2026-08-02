using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using UnityEngine;
using UnityEngine.UI;

public class JsonNetSample : MonoBehaviour
{
	public class Product
	{
		public string Name;

		public DateTime ExpiryDate = new DateTime(2000, 1, 1, 0, 0, 0, DateTimeKind.Utc);

		public decimal Price;

		public string[] Sizes;

		public override bool Equals(object obj)
		{
			if (obj is Product)
			{
				Product product = (Product)obj;
				if (product.Name == Name && product.ExpiryDate == ExpiryDate)
				{
					return product.Price == Price;
				}
				return false;
			}
			return base.Equals(obj);
		}

		public override int GetHashCode()
		{
			return (Name ?? string.Empty).GetHashCode();
		}
	}

	[Serializable]
	public class CharacterListItem
	{
		public int Id { get; set; }

		public string Name { get; set; }

		public int Level { get; set; }

		public string Class { get; set; }

		public string Sex { get; set; }
	}

	public class Movie
	{
		public string Name { get; set; }

		public string Description { get; set; }

		public string Classification { get; set; }

		public string Studio { get; set; }

		public DateTime? ReleaseDate { get; set; }

		public List<string> ReleaseCountries { get; set; }
	}

	public Text Output;

	private void Start()
	{
		Output.text = "Start!\n\n";
		TestJson();
		SerailizeJson();
		DeserializeJson();
		LinqToJson();
		JsonPath();
		WriteLine("\nDone!");
	}

	private void WriteLine(string msg)
	{
		Output.text = Output.text + msg + "\n";
	}

	private void TestJson()
	{
		WriteLine("* TestJson");
		CharacterListItem characterListItem = JsonConvert.DeserializeObject<CharacterListItem>("{\"Id\":51, \"Name\":\"padre\", \"Level\":0, \"Class\":\"Vampire\", \"Sex\":\"F\"}");
		WriteLine(characterListItem.Id + " " + characterListItem.Name);
	}

	private void SerailizeJson()
	{
		WriteLine("* SerailizeJson");
		Product product = new Product();
		product.Name = "Apple";
		product.ExpiryDate = new DateTime(2008, 12, 28);
		product.Sizes = new string[1] { "Small" };
		string msg = JsonConvert.SerializeObject(product);
		WriteLine(msg);
	}

	private void DeserializeJson()
	{
		WriteLine("* DeserializeJson");
		string msg = JsonConvert.DeserializeObject<Movie>("{\r\n          'Name': 'Bad Boys',\r\n          'ReleaseDate': '1995-4-7T00:00:00',\r\n          'Genres': [\r\n            'Action',\r\n            'Comedy'\r\n          ]\r\n        }").Name;
		WriteLine(msg);
	}

	private void LinqToJson()
	{
		WriteLine("* LinqToJson");
		JArray jArray = new JArray();
		jArray.Add("Manual text");
		jArray.Add(new DateTime(2000, 5, 23));
		string msg = new JObject { ["MyArray"] = jArray }.ToString();
		WriteLine(msg);
	}

	private void JsonPath()
	{
		WriteLine("* JsonPath");
		JObject jObject = JObject.Parse("{\r\n            'Stores': [\r\n            'Lambton Quay',\r\n            'Willis Street'\r\n            ],\r\n            'Manufacturers': [\r\n            {\r\n                'Name': 'Acme Co',\r\n                'Products': [\r\n                {\r\n                    'Name': 'Anvil',\r\n                    'Price': 50\r\n                }\r\n                ]\r\n            },\r\n            {\r\n                'Name': 'Contoso',\r\n                'Products': [\r\n                {\r\n                    'Name': 'Elbow Grease',\r\n                    'Price': 99.95\r\n                },\r\n                {\r\n                    'Name': 'Headlight Fluid',\r\n                    'Price': 4\r\n                }\r\n                ]\r\n            }\r\n            ]\r\n        }");
		JToken jToken = jObject.SelectToken("$.Manufacturers[?(@.Name == 'Acme Co')]");
		WriteLine(jToken.ToString());
		foreach (JToken item in jObject.SelectTokens("$..Products[?(@.Price >= 50)].Name"))
		{
			WriteLine(item.ToString());
		}
	}
}
