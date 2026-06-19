using System;
using System.Collections.Generic;
using Loxodon.Framework.Configurations;
using UnityEngine;

namespace Loxodon.Framework.Tutorials
{
	public class ConfigurationExample : MonoBehaviour
	{
		private void Start()
		{
			IConfiguration configuration = CreateConfiguration();
			Version version = configuration.GetVersion("application.app.version");
			Version version2 = configuration.GetVersion("application.data.version");
			Debug.LogFormat("application.app.version:{0}", version);
			Debug.LogFormat("application.data.version:{0}", version2);
			string text = configuration.GetString("application.config-group");
			IConfiguration configuration2 = configuration.Subset("application." + text);
			string text2 = configuration2.GetString("upgrade.url");
			string text3 = configuration2.GetString("username");
			string text4 = configuration2.GetString("password");
			string[] array = configuration2.GetArray<string>("gateway");
			Debug.LogFormat("upgrade.url:{0}", text2);
			Debug.LogFormat("username:{0}", text3);
			Debug.LogFormat("password:{0}", text4);
			int num = 1;
			string[] array2 = array;
			foreach (string text5 in array2)
			{
				Debug.LogFormat("gateway {0}:{1}", num++, text5);
			}
		}

		private IConfiguration CreateConfiguration()
		{
			List<IConfiguration> list = new List<IConfiguration>();
			TextAsset textAsset = Resources.Load<TextAsset>("application.properties");
			list.Add(new PropertiesConfiguration(textAsset.text));
			textAsset = Resources.Load<TextAsset>($"application.{Application.platform.ToString().ToLower()}.properties");
			if (textAsset != null)
			{
				list.Add(new PropertiesConfiguration(textAsset.text));
			}
			if (list.Count == 1)
			{
				return list[0];
			}
			return new CompositeConfiguration(list);
		}
	}
}
