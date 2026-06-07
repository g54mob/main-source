using UnityEngine;

namespace MoreMountains.Tools
{
	[AddComponentMenu("More Mountains/Tools/Utilities/MM Open URL")]
	public class MMOpenURL : MonoBehaviour
	{
		public string DestinationURL;

		public virtual void OpenURL()
		{
			Application.OpenURL(DestinationURL);
		}
	}
}
