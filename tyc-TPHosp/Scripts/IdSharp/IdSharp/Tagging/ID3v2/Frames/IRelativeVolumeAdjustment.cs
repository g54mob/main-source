using System.ComponentModel;

namespace IdSharp.Tagging.ID3v2.Frames
{
	public interface IRelativeVolumeAdjustment : IFrame, INotifyPropertyChanged
	{
		string Identification { get; set; }

		decimal FrontRightAdjustment { get; set; }

		decimal FrontLeftAdjustment { get; set; }

		decimal BackRightAdjustment { get; set; }

		decimal BackLeftAdjustment { get; set; }

		decimal FrontCenterAdjustment { get; set; }

		decimal SubwooferAdjustment { get; set; }

		decimal BackCenterAdjustment { get; set; }

		decimal OtherAdjustment { get; set; }

		decimal MasterAdjustment { get; set; }

		decimal FrontRightPeak { get; set; }

		decimal FrontLeftPeak { get; set; }

		decimal BackRightPeak { get; set; }

		decimal BackLeftPeak { get; set; }

		decimal FrontCenterPeak { get; set; }

		decimal SubwooferPeak { get; set; }

		decimal BackCenterPeak { get; set; }

		decimal OtherPeak { get; set; }

		decimal MasterPeak { get; set; }
	}
}
