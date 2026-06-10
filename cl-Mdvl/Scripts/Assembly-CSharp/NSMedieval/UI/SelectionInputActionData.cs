using System;
using System.Collections.Generic;
using NSEipix.Base;
using NSEipix.Repository;
using NSMedieval.Enums;
using NSMedieval.Model;
using NSMedieval.Repository;
using UnityEngine;

namespace NSMedieval.UI
{
	[Serializable]
	public class SelectionInputActionData : NSEipix.Base.Model
	{
		[SerializeField]
		private string id;

		[SerializeField]
		private string iconPath;

		[SerializeField]
		private LocKeys[] locKeys;

		[SerializeField]
		private KeyInputEvent keyInputEvent;

		public string IconPath => iconPath;

		public LocKeys[] LocKeys => locKeys;

		public KeyInputEvent KeyInputEvent => keyInputEvent;

		public override string GetID()
		{
			return id;
		}

		public static KeyValuePair<SelectionInputActionData, Action> NewAction(string dataId, Action action)
		{
			return new KeyValuePair<SelectionInputActionData, Action>(Repository<ObjectActionDataRepository, SelectionInputActionData>.Instance.GetByID(dataId), action);
		}
	}
}
