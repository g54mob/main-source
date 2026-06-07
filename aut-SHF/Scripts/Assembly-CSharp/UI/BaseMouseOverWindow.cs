using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
	public class BaseMouseOverWindow : MonoBehaviour
	{
		public ContentSizeFitter contentSizeFilter;

		public TMP_Text title;

		public TMP_Text message;

		public virtual void InitComponent(BaseMouseOverWindowParam param)
		{
		}

		public void SetMassage(string str)
		{
		}

		public void SetTitle(string str)
		{
		}
	}
}
