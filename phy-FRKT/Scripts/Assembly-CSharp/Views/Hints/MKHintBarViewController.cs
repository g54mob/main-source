using System.Collections.Generic;
using Player.GameplayInput.ButtonsActions;
using Player.GameplayInput.ButtonsActions.MouseKeyboard;
using Player.GameplayInput.ButtonsActions.MouseKeyboard.Actions;
using UnityEngine;
using Zenject;

namespace Views.Hints
{
	public class MKHintBarViewController : ex
	{
		private ly puc;

		private HintBarViewController pud;

		[SerializeField]
		private List<MKButtonActionType> m_hintedActionTypes;

		private HashSet<MKButtonActionType> pue;

		[Inject]
		private void duv(ly a)
		{
		}

		public override IEnumerable<ButtonActionData> duh(HintBarViewController a)
		{
			return null;
		}

		private IEnumerable<ButtonActionData> duw()
		{
			return null;
		}

		private void dux(MKButtonActionData a)
		{
		}

		private void duy(MKButtonActionData a)
		{
		}
	}
}
