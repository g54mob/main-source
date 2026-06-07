using UnityEngine;
using UnityEngine.UI;

namespace Borodar.FarlandSkies.Core.Demo
{
	public abstract class BaseColorButton : MonoBehaviour
	{
		public ColorPicker ColorPicker;

		protected Image ColorImage;

		protected void Awake()
		{
		}

		public void OnClick()
		{
		}

		public virtual void ChangeColor(Color color)
		{
		}
	}
}
