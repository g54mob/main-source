using UnityEngine;
using UnityEngine.EventSystems;

namespace Placemaker.Ui
{
	public class GameViewRect : UIBehaviour
	{
		[SerializeField]
		private UiMaster uiMaster;

		[SerializeField]
		public RectTransform sliding;

		public float left
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public float bottom
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public float right
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public float top
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public Rect GetRelativeRect()
		{
			return default(Rect);
		}
	}
}
