using app.vis;
using data;
using haxe.lang;

namespace play.day.booth
{
	public interface IStampBar : IHxObject
	{
		Function set_whenApplyInk(Function value);

		bool get_open();

		bool set_open(bool value);

		bool set_enabled(bool value);

		bool set_reasonStampEnabled(bool value);

		DeskItem get_stampingSoloDeskItem();

		bool get_flagEnableReact();

		bool set_flagEnableReact(bool value);

		Rect autoGetOpenStampRect(StampApprovalKind approvalKind);

		PointData autoStampClickWorldPos(StampApprovalKind approvalKind);

		bool autoIsAnimating();
	}
}
