using UnityEngine;
using UnityEngine.UI;

namespace Utility
{
	public class MaterialFixer : MonoBehaviour
	{
		private void Awake()
		{
			base.gameObject.AddComponent<Image>().material.color = Color.white;
		}
	}
}
