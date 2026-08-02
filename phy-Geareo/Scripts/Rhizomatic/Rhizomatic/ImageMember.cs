using Rhizomatic.Reactive;
using UnityEngine;
using UnityEngine.UI;

namespace Rhizomatic
{
	public class ImageMember : GraphicMember<Image>, ICrewRenderer
	{
		public Sprite sprite
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public void CrewRender(object value)
		{
		}
	}
}
