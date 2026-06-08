using Rhizomatic.Reactive;
using UnityEngine;
using UnityEngine.UI;

namespace Rhizomatic
{
	public class RawImageMember : GraphicMember<RawImage>, ICrewRenderer
	{
		public Texture texture
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
