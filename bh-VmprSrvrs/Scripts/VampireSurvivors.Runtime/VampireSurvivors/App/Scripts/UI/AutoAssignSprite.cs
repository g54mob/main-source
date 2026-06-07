using UnityEngine;
using UnityEngine.UI;

namespace VampireSurvivors.App.Scripts.UI
{
	[RequireComponent(typeof(Image))]
	public class AutoAssignSprite : MonoBehaviour
	{
		[SerializeField]
		private string _SpriteName;

		[SerializeField]
		private string _TextureName;

		private void Start()
		{
		}
	}
}
