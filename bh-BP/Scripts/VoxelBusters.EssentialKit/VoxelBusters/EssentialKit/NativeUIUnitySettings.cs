using System;
using UnityEngine;
using VoxelBusters.CoreLibrary;
using VoxelBusters.CoreLibrary.NativePlugins.UnityUI;
using VoxelBusters.EssentialKit.NativeUICore;

namespace VoxelBusters.EssentialKit
{
	[Serializable]
	public class NativeUIUnitySettings : SettingsPropertyGroup
	{
		[Serializable]
		public class UnityUICollection
		{
			[SerializeField]
			[Tooltip("Canvas used to render native plugins components (primarily simulator window).")]
			private UnityUIRenderer m_rendererPrefab;

			[SerializeField]
			[Tooltip("Custom alert dialog prefab. Object should implement IUnityUIAlertDialog interface.")]
			private UnityUIAlertDialog m_alertDialogPrefab;

			[SerializeField]
			private UnityUIDatePicker m_datePickerPrefab;

			public UnityUIRenderer RendererPrefab
			{
				get
				{
					return null;
				}
				internal set
				{
				}
			}

			public UnityUIAlertDialog AlertDialogPrefab
			{
				get
				{
					return null;
				}
				internal set
				{
				}
			}

			public UnityUIDatePicker DatePickerPrefab
			{
				get
				{
					return null;
				}
				internal set
				{
				}
			}

			public UnityUICollection(UnityUIRenderer rendererPrefab = null, UnityUIAlertDialog alertDialogPrefab = null, UnityUIDatePicker datePickerPrefab = null)
			{
			}
		}

		[SerializeField]
		[Tooltip("Custom assets references.")]
		private UnityUICollection m_customUICollection;

		public UnityUICollection CustomUICollection => null;

		public NativeUIUnitySettings(bool isEnabled = true, UnityUICollection customUICollection = null)
			: base(null, isEnabled: false)
		{
		}
	}
}
