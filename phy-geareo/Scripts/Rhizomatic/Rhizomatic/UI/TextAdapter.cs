using UnityEngine;

namespace Rhizomatic.UI
{
	public abstract class TextAdapter : UIAdapter<string>
	{
		public string text
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public abstract Color color { get; set; }
	}
}
