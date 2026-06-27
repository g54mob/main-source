using System;
using FullSerializer;
using Restory.Data.Restrictions;
using Restory.Data.SaveLoad.FullSerializerWrappers.GameEntities;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Restory.Data.Base
{
	[Serializable]
	[fsObject(Processor = typeof(GameEntityProcessor))]
	public abstract class RestoryEntityInfoBase : SerializedScriptableObject
	{
		[SerializeField]
		private ContentRestrictionBase contentRestriction;

		[SerializeField]
		private string id = string.Empty;

		[SerializeField]
		private Sprite icon;

		public ContentRestrictionBase ContentRestriction => contentRestriction;

		public string ID => id;

		public Sprite Icon => icon;

		protected virtual void OnValidate()
		{
			FillEmptyFields();
		}

		protected virtual void FillEmptyFields()
		{
		}
	}
}
