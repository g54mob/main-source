using System;
using System.Collections.Generic;
using UnityEngine;

namespace NSMedieval
{
	[Serializable]
	public class HeraldryPresets
	{
		[SerializeField]
		private string creator;

		[SerializeField]
		private TextureWrapMode patternWrapMode;

		[SerializeField]
		private List<HeraldryData> heraldry = new List<HeraldryData>();

		[SerializeField]
		private List<string> customHeraldryImages = new List<string>();

		public string Creator
		{
			get
			{
				return creator;
			}
			set
			{
				creator = value;
			}
		}

		public List<HeraldryData> Heraldry
		{
			get
			{
				return heraldry;
			}
			set
			{
				heraldry = value;
			}
		}

		public List<string> CustomHeraldryImages
		{
			get
			{
				return customHeraldryImages;
			}
			set
			{
				customHeraldryImages = value;
			}
		}

		public TextureWrapMode PatternWrapMode
		{
			get
			{
				return patternWrapMode;
			}
			set
			{
				patternWrapMode = value;
			}
		}
	}
}
