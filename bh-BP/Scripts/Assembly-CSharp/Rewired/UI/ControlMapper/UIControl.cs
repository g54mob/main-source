using System;
using UnityEngine;
using UnityEngine.UI;

namespace Rewired.UI.ControlMapper
{
	[AddComponentMenu(null)]
	public class UIControl : MonoBehaviour
	{
		public Text title;

		private int _id;

		private bool _showTitle;

		private static int _uidCounter;

		public int id => 0;

		public bool showTitle
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		private void Awake()
		{
		}

		public virtual void SetCancelCallback(Action cancelCallback)
		{
		}

		private static int GetNextUid()
		{
			return 0;
		}
	}
}
