using System;
using VoxelBusters.CoreLibrary.NativePlugins;

namespace VoxelBusters.EssentialKit.SharingServicesCore
{
	public sealed class NullSharingInterface : NativeSharingInterfaceBase, INativeSharingInterface, INativeFeatureInterface, INativeObject, IDisposable
	{
		public NullSharingInterface()
			: base(isAvailable: false)
		{
		}

		public override bool CanSendMail()
		{
			return false;
		}

		public override INativeMailComposer CreateMailComposer()
		{
			return null;
		}

		public override bool CanSendText()
		{
			return false;
		}

		public override bool CanSendAttachments()
		{
			return false;
		}

		public override bool CanSendSubject()
		{
			return false;
		}

		public override INativeMessageComposer CreateMessageComposer()
		{
			return null;
		}

		public override INativeShareSheet CreateShareSheet()
		{
			return null;
		}

		public override bool IsSocialShareComposerAvailable(SocialShareComposerType composerType)
		{
			return false;
		}

		public override INativeSocialShareComposer CreateSocialShareComposer(SocialShareComposerType composerType)
		{
			return null;
		}
	}
}
