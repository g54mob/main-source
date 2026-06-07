using UnityEngine;

namespace MoreMountains.Tools
{
	[AddComponentMenu(null)]
	public class MMPersistentBase : MonoBehaviour, IMMPersistent
	{
		[Tooltip("whether or not this object should be saved")]
		[Header("Save")]
		public bool SaveActive;

		[Tooltip("an optional suffix to add to the GUID, to make it more readable")]
		[Header("ID")]
		public string UniqueIDSuffix;

		[Tooltip("the object's unique ID")]
		[MMReadOnly]
		[SerializeField]
		protected string _guid;

		[MMInspectorButton("GenerateGuid")]
		public bool GenerateGuidButton;

		protected virtual void OnValidate()
		{
		}

		public virtual string GetGuid()
		{
			return null;
		}

		public virtual void SetGuid(string newGUID)
		{
		}

		public virtual string OnSave()
		{
			return null;
		}

		public virtual void OnLoad(string data)
		{
		}

		public virtual bool ShouldBeSaved()
		{
			return false;
		}

		public virtual string GenerateGuid()
		{
			return null;
		}

		public virtual bool GuidIsUnique(string guid)
		{
			return false;
		}

		public virtual void ValidateGuid()
		{
		}
	}
}
