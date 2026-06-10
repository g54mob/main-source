using System;
using System.Linq;
using UnityEngine;

namespace MoreMountains.Tools
{
	[AddComponentMenu("")]
	public class MMPersistentBase : MonoBehaviour, IMMPersistent
	{
		[Header("Save")]
		[Tooltip("whether or not this object should be saved")]
		public bool SaveActive = true;

		[Header("ID")]
		[Tooltip("an optional suffix to add to the GUID, to make it more readable")]
		public string UniqueIDSuffix;

		[Tooltip("the object's unique ID")]
		[SerializeField]
		[MMReadOnly]
		protected string _guid;

		[MMInspectorButton("GenerateGuid")]
		public bool GenerateGuidButton;

		protected virtual void OnValidate()
		{
			ValidateGuid();
		}

		public virtual string GetGuid()
		{
			return _guid;
		}

		public virtual void SetGuid(string newGUID)
		{
			_guid = newGUID;
		}

		public virtual string OnSave()
		{
			return string.Empty;
		}

		public virtual void OnLoad(string data)
		{
		}

		public virtual bool ShouldBeSaved()
		{
			return SaveActive;
		}

		public virtual string GenerateGuid()
		{
			string text = Guid.NewGuid().ToString();
			string text2 = base.gameObject.scene.name + "-" + base.gameObject.name + "-" + text;
			if (!string.IsNullOrEmpty(UniqueIDSuffix))
			{
				text2 = text2 + "-" + UniqueIDSuffix;
			}
			SetGuid(text2);
			return text2;
		}

		public virtual bool GuidIsUnique(string guid)
		{
			return Resources.FindObjectsOfTypeAll<MMPersistentBase>().Count((MMPersistentBase x) => x.GetGuid() == guid) == 1;
		}

		public virtual void ValidateGuid()
		{
			if (!base.gameObject.scene.IsValid())
			{
				_guid = string.Empty;
				return;
			}
			int num = 1000;
			int num2 = 0;
			while ((string.IsNullOrEmpty(_guid) || !GuidIsUnique(_guid)) && num2 < num)
			{
				GenerateGuid();
				num2++;
			}
			if (num2 == num)
			{
				Debug.LogWarning(base.gameObject.name + " couldn't generate a unique GUID after " + num + " tries, you should probably change its UniqueIDSuffix");
			}
		}
	}
}
