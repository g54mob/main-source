using UnityEngine;

namespace LeTai.Asset.TranslucentImage.Demo
{
	public class UnrestrictFramerate : MonoBehaviour
	{
		private void Start()
		{
			Application.targetFrameRate = 120;
		}
	}
}
