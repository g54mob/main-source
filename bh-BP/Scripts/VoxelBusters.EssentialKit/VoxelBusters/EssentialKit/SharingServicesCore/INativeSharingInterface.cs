using System;
using VoxelBusters.CoreLibrary.NativePlugins;

namespace VoxelBusters.EssentialKit.SharingServicesCore
{
	public interface INativeSharingInterface : INativeFeatureInterface, INativeObject, IDisposable
	{
		bool CanSendMail();

		INativeMailComposer CreateMailComposer();

		bool CanSendText();

		bool CanSendAttachments();

		bool CanSendSubject();

		INativeMessageComposer CreateMessageComposer();

		INativeShareSheet CreateShareSheet();

		bool IsSocialShareComposerAvailable(SocialShareComposerType composerType);

		INativeSocialShareComposer CreateSocialShareComposer(SocialShareComposerType composerType);
	}
}
