using System;
using System.Collections.Specialized;
using I18n;
using UnityEngine;

namespace Gh.Tk
{
	public class ActiveTasks3DUIView : BaseInteractable3DUIView
	{
		public Transform[] icons;

		public TextMeshProI18n numberValueText;

		private GameObjectX _gox;

		protected override void Awake()
		{
		}

		protected override void OnDestroy()
		{
		}

		private void JobStateChanged(object sender, EventArgs e)
		{
		}

		private void JobsChanged(object sender, NotifyCollectionChangedEventArgs e)
		{
		}

		public void SetData(GameObjectX gox)
		{
		}

		protected override TooltipData GetTooltipDataInternal()
		{
			return null;
		}

		public override void CheckState()
		{
		}
	}
}
