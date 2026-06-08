using System;
using System.Collections.Generic;
using System.Xml;
using UnityEngine;

public static class DVPConfigurationManager
{
	private class DVPDefinition
	{
		private Dictionary<string, Dictionary<string, object>> definitionDict;

		public string cameraGroup { get; private set; }

		private DVPDefinition()
		{
		}

		public DVPDefinition(string cameraGroup)
		{
			this.cameraGroup = cameraGroup;
		}

		public void AddValue(string propertyName, string name, object value)
		{
			if (definitionDict == null)
			{
				definitionDict = new Dictionary<string, Dictionary<string, object>>();
			}
			if (!definitionDict.ContainsKey(propertyName))
			{
				definitionDict.Add(propertyName, new Dictionary<string, object>());
			}
			if (!definitionDict[propertyName].ContainsKey(name))
			{
				definitionDict[propertyName].Add(name, value);
			}
			else
			{
				Debug.LogWarning(string.Format("DVPDefinition.AddValue() called with a name ('{0}') that already exists for the '{1}' property type.  Ignored.", name, propertyName));
			}
		}

		public bool GetBool(string propertyName, string name, bool defaultValue)
		{
			bool result = defaultValue;
			if (definitionDict != null && definitionDict.ContainsKey(propertyName) && definitionDict[propertyName].ContainsKey(name))
			{
				bool.TryParse(definitionDict[propertyName][name].ToString(), out result);
			}
			return result;
		}

		public string GetString(string propertyName, string name, string defaultValue)
		{
			string result = defaultValue;
			if (definitionDict != null && definitionDict.ContainsKey(propertyName) && definitionDict[propertyName].ContainsKey(name))
			{
				result = definitionDict[propertyName][name].ToString();
			}
			return result;
		}

		public Color GetColor(string propertyName, string name, Color defaultValue)
		{
			Color color = defaultValue;
			if (definitionDict != null && definitionDict.ContainsKey(propertyName) && definitionDict[propertyName].ContainsKey(name))
			{
				Color color2 = color;
				try
				{
					color2 = (Color)definitionDict[propertyName][name];
					color = color2;
				}
				catch (Exception)
				{
					int num = 0;
					num++;
				}
			}
			return color;
		}

		public T GetNumeric<T>(string propertyName, string name, T defaultValue)
		{
			T result = defaultValue;
			if (definitionDict != null && definitionDict.ContainsKey(propertyName) && definitionDict[propertyName].ContainsKey(name))
			{
				try
				{
					result = (T)Convert.ChangeType(definitionDict[propertyName][name].ToString(), typeof(T));
				}
				catch (Exception)
				{
					int num = 0;
					num++;
				}
			}
			return result;
		}
	}

	private static Dictionary<string, DVPDefinition> dvpDict;

	private static bool isInitialized;

	public static void Initalize()
	{
		if (!isInitialized)
		{
			dvpDict = new Dictionary<string, DVPDefinition>();
			LoadDungeonTypeLibrary();
			isInitialized = true;
		}
	}

	private static void LoadDungeonTypeLibrary()
	{
		TextAsset textAsset = ResourceManager.LoadAsset<TextAsset>("Data/DVPDefinitions");
		XmlDocument xmlDocument = new XmlDocument();
		xmlDocument.LoadXml(textAsset.text);
		XmlNodeList xmlNodeList = xmlDocument.SelectNodes("//DVPDefinitions/DVP");
		if (xmlNodeList.Count <= 0)
		{
			return;
		}
		foreach (XmlNode item in xmlNodeList)
		{
			if (item.Attributes["name"] == null || item.Attributes["cameraGroup"] == null)
			{
				Debug.LogError("<DVP>, in DVPDefinitions, requires a 'name' and 'cameraGroup' attribute");
				continue;
			}
			string value = item.Attributes["name"].Value;
			string value2 = item.Attributes["cameraGroup"].Value;
			if (!dvpDict.ContainsKey(value))
			{
				DVPDefinition dVPDefinition = new DVPDefinition(value2);
				dvpDict.Add(value, dVPDefinition);
				if (!item.HasChildNodes)
				{
					continue;
				}
				foreach (XmlNode childNode in item.ChildNodes)
				{
					string name = childNode.Name;
					foreach (XmlAttribute attribute in childNode.Attributes)
					{
						bool flag = true;
						if (attribute.Value.Contains(","))
						{
							string[] array = attribute.Value.Split(new char[1] { ',' }, StringSplitOptions.RemoveEmptyEntries);
							if (array.Length == 3 || array.Length == 4)
							{
								int result = -1;
								int result2 = -1;
								int result3 = -1;
								int result4 = -1;
								int.TryParse(array[0], out result);
								int.TryParse(array[1], out result2);
								int.TryParse(array[2], out result3);
								if (array.Length == 4)
								{
									int.TryParse(array[3], out result4);
								}
								else
								{
									result4 = 255;
								}
								if (result >= 0 && result2 >= 0 && result3 >= 0 && result4 >= 0)
								{
									float r = (float)result / 255f;
									float g = (float)result2 / 255f;
									float b = (float)result3 / 255f;
									float a = (float)result4 / 255f;
									dVPDefinition.AddValue(value: new Color(r, g, b, a), propertyName: name, name: attribute.Name);
									flag = false;
								}
							}
						}
						if (flag)
						{
							dVPDefinition.AddValue(name, attribute.Name, attribute.Value);
						}
					}
				}
			}
			else
			{
				Debug.LogWarning(string.Format("dvpDict already has en entry for {0}.  Duplicate ignored.", value));
			}
		}
	}

	public static string GetCameraGroup(string dvpName)
	{
		if (dvpDict != null && dvpDict.ContainsKey(dvpName))
		{
			return dvpDict[dvpName].cameraGroup;
		}
		return null;
	}

	public static bool GetBool(string dvpName, string propertyName, string name, bool defaultValue)
	{
		bool result = defaultValue;
		if (dvpDict != null && dvpDict.ContainsKey(dvpName))
		{
			result = dvpDict[dvpName].GetBool(propertyName, name, defaultValue);
		}
		return result;
	}

	public static string GetString(string dvpName, string propertyName, string name, string defaultValue)
	{
		string result = defaultValue;
		if (dvpDict != null && dvpDict.ContainsKey(dvpName))
		{
			result = dvpDict[dvpName].GetString(propertyName, name, defaultValue);
		}
		return result;
	}

	public static T GetNumeric<T>(string dvpName, string propertyName, string name, T defaultValue)
	{
		T result = default(T);
		if (dvpDict != null && dvpDict.ContainsKey(dvpName))
		{
			result = dvpDict[dvpName].GetNumeric(propertyName, name, defaultValue);
		}
		return result;
	}

	public static T GetRandomNumeric<T>(string dvpName, string propertyName, string nameBase, T defaultValue)
	{
		T result = defaultValue;
		if (dvpDict != null && dvpDict.ContainsKey(dvpName))
		{
			string name = nameBase + "Min";
			string name2 = nameBase + "Max";
			T numeric = dvpDict[dvpName].GetNumeric(propertyName, name, defaultValue);
			T numeric2 = dvpDict[dvpName].GetNumeric(propertyName, name2, numeric);
			if (typeof(T) == typeof(int))
			{
				int min = (int)Convert.ChangeType(numeric, typeof(int));
				int max = (int)Convert.ChangeType(numeric2, typeof(int));
				result = (T)Convert.ChangeType(UnityEngine.Random.Range(min, max), typeof(T));
			}
			else if (typeof(T) == typeof(float))
			{
				float min2 = (float)Convert.ChangeType(numeric, typeof(float));
				float max2 = (float)Convert.ChangeType(numeric2, typeof(float));
				result = (T)Convert.ChangeType(UnityEngine.Random.Range(min2, max2), typeof(T));
			}
		}
		return result;
	}

	public static Color GetColor(string dvpName, string propertyName, string name, Color defaultValue)
	{
		Color result = defaultValue;
		if (dvpDict != null && dvpDict.ContainsKey(dvpName))
		{
			result = dvpDict[dvpName].GetColor(propertyName, name, defaultValue);
		}
		return result;
	}

	public static Color GetRandomColor(string dvpName, string propertyName, string nameBase, Color defaultValue)
	{
		Color result = defaultValue;
		if (dvpDict != null && dvpDict.ContainsKey(dvpName))
		{
			string name = nameBase + "Min";
			string name2 = nameBase + "Max";
			Color color = dvpDict[dvpName].GetColor(propertyName, name, defaultValue);
			Color color2 = dvpDict[dvpName].GetColor(propertyName, name2, color);
			float t = UnityEngine.Random.Range(0f, 1f);
			result = Color.Lerp(color, color2, t);
		}
		return result;
	}
}
