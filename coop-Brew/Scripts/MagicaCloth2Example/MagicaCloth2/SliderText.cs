using UnityEngine;
using UnityEngine.UI;

namespace MagicaCloth2
{
	public class SliderText : MonoBehaviour
	{
		[SerializeField]
		private Text text;

		[SerializeField]
		private string lable;

		[SerializeField]
		private string format;

		private string formatString;

		protected void Start()
		{
		}

		private void OnChangeValue(float value)
		{
		}
	}
}
