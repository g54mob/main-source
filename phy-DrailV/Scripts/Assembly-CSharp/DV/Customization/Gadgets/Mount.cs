using System.Collections.Generic;
using System.Collections.ObjectModel;
using DV.JObjectExtstensions;
using Newtonsoft.Json.Linq;
using UnityEngine;

namespace DV.Customization.Gadgets
{
	[RequireComponent(typeof(GadgetBase))]
	public class Mount : GadgetComponent
	{
		public abstract class AttachmentOption : MonoBehaviour
		{
			public Mount Owner { get; private set; }

			public abstract bool Accepts(GadgetBase gadget);

			protected virtual void Awake()
			{
				Owner = GetComponentInParent<Mount>();
				if (!(Owner == null))
				{
					Owner.attachment.Add(this);
				}
			}

			protected virtual void OnDestroy()
			{
				if (!(Owner == null))
				{
					Owner.attachment.Remove(this);
				}
			}

			public abstract void GetPossibleAttachmentPositions(GadgetBase gadget, List<AttachmentPosition> destination);
		}

		private static readonly List<AttachmentPosition> positionsBuilder = new List<AttachmentPosition>();

		private const string KEY_MOUNTED_GADGET_UID = "mounted";

		private readonly List<AttachmentOption> attachment = new List<AttachmentOption>();

		public GadgetBase MountedGadget { get; private set; }

		public ReadOnlyCollection<AttachmentOption> AttachmentMethods { get; private set; }

		public bool IsInUse => MountedGadget != null;

		public override GadgetBase.GadgetRemovalMethod GetValidRemovalMethodsMask()
		{
			if (IsInUse)
			{
				return GadgetBase.GadgetRemovalMethod.None;
			}
			return GadgetBase.GadgetRemovalMethod.Any;
		}

		protected override void Awake()
		{
			base.Awake();
			AttachmentMethods = attachment.AsReadOnly();
			base.ThisGadget.ForceRemoveCalled += OnForceRemoveCalled;
		}

		public bool Accepts(GadgetBase gadget)
		{
			foreach (AttachmentOption item in attachment)
			{
				if (item.Accepts(gadget))
				{
					return true;
				}
			}
			return false;
		}

		public AttachmentPosition[] GetAttachmentPositions(GadgetBase gadget)
		{
			positionsBuilder.Clear();
			foreach (AttachmentOption item in attachment)
			{
				if (item.Accepts(gadget))
				{
					item.GetPossibleAttachmentPositions(gadget, positionsBuilder);
				}
			}
			AttachmentPosition[] result = positionsBuilder.ToArray();
			positionsBuilder.Clear();
			return result;
		}

		public Vector3 AttachmentTransform(AttachmentPosition pos, out Quaternion rotation)
		{
			rotation = base.transform.rotation * pos.rotation;
			return base.transform.TransformPoint(pos.offset);
		}

		public void MountGadget(GadgetBase gadget)
		{
			if (IsInUse)
			{
				Debug.LogError("[CUSTOMIZATION] Cannot mount a gadget: Mount is already occupied!");
				return;
			}
			if (gadget.MountedOn != null)
			{
				Debug.LogError("[CUSTOMIZATION] Cannot mount a gadget: Gadget is already mounted!");
				return;
			}
			MountedGadget = gadget;
			gadget.MountedOn = this;
		}

		public void UnmountGadget()
		{
			if (!(MountedGadget == null))
			{
				MountedGadget.MountedOn = null;
				MountedGadget = null;
			}
		}

		private void OnForceRemoveCalled(object _, bool reparentToTrainCar)
		{
			if (MountedGadget != null)
			{
				MountedGadget.Remove(reparentToTrainCar);
				UnmountGadget();
			}
		}

		protected internal override void SaveDataRequested(JObject dst)
		{
			if (!(base.ThisGadget.Custom == null))
			{
				dst.SetInt("mounted", (MountedGadget != null) ? MountedGadget.UID : 0);
			}
		}

		protected internal override void AfterSaveDataLoaded(JObject src)
		{
			if (base.ThisGadget.Custom == null)
			{
				return;
			}
			int num = src.GetInt("mounted") ?? 0;
			if (num != 0)
			{
				if (base.ThisGadget.Custom.TryGetCustomizerByUID(num, out var customizer) && customizer is GadgetBase gadget)
				{
					MountGadget(gadget);
				}
				else
				{
					Debug.LogError("[CUSTOMIZATION] Could not load a mounted gadget because it was not found!", this);
				}
			}
		}
	}
}
