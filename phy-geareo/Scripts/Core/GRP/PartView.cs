using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Rhizomatic.MemberBinding;
using Rhizomatic.Reactive;

namespace GRP
{
	public abstract class PartView : View
	{
		public List<SnapPoint> snapPoints;

		private bool dirtyPart;

		private bool dirtyTransform;

		public ProjectView projectView { get; set; }

		public new PartViewable viewable => null;

		public event Action onPartRendered
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		public event Action onTransformRendered
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		protected override void LateUpdate()
		{
		}

		private void MarkDirtyPart()
		{
		}

		private void MarkDirtyTransform()
		{
		}

		protected override void OnViewOpen()
		{
		}

		protected override void OnViewClose()
		{
		}

		public void ReadTransform()
		{
		}

		public virtual void ApplyTransform()
		{
		}
	}
	[CustomMemberBinding]
	public abstract class PartView<T> : PartView where T : PartViewable
	{
		public override Type viewableType => null;

		public new T viewable => null;

		public static void MemberBinder_CustomMemberBinding(MemberBindData bindData)
		{
		}
	}
}
