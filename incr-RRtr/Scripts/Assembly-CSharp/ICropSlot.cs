public interface ICropSlot
{
	CropType _CropType { get; set; }

	int _CropState { get; set; }

	float _CropProgress { get; set; }

	int _CropMultiplier { get; set; }

	float _CropFertilizer { get; set; }

	bool _CropImproved { get; set; }

	void ForceUpdateCropSlot();
}
