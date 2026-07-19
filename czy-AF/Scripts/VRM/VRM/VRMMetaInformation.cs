using System;
using UniGLTF;
using UnityEngine;

namespace VRM
{
	[Serializable]
	[Obsolete("reimport, use VRMMeta. Please reimport")]
	[DisallowMultipleComponent]
	public class VRMMetaInformation : MonoBehaviour, IEquatable<VRMMetaInformation>
	{
		[SerializeField]
		[Header("Information")]
		public string Title;

		[SerializeField]
		public string Author;

		[SerializeField]
		public string ContactInformation;

		[SerializeField]
		public Texture2D Thumbnail;

		[SerializeField]
		public string Reference;

		[SerializeField]
		[Header("License")]
		public LicenseType LicenseType;

		[SerializeField]
		public string OtherLicenseUrl;

		public bool Equals(VRMMetaInformation other)
		{
			if (Author == other.Author && Title == other.Title)
			{
				return MonoBehaviourComparator.AssetAreEquals(Thumbnail, other.Thumbnail);
			}
			return false;
		}

		private void Reset()
		{
			Title = base.name;
		}

		public void CopyTo(GameObject _dst)
		{
			VRMMetaInformation vRMMetaInformation = _dst.AddComponent<VRMMetaInformation>();
			vRMMetaInformation.Title = Title;
			vRMMetaInformation.Author = Author;
			vRMMetaInformation.Thumbnail = Thumbnail;
		}

		public void OnValidate()
		{
			if (Thumbnail != null && (Thumbnail.width != 2048 || Thumbnail.height != 2048))
			{
				Thumbnail = null;
				Debug.LogError("Thumbnail must 2048 x 2048");
			}
		}
	}
}
