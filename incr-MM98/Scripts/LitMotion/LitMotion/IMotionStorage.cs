namespace LitMotion
{
	internal interface IMotionStorage
	{
		bool IsValid(MotionHandle handle);

		bool IsActive(MotionHandle handle);

		bool IsPlaying(MotionHandle handle);

		bool TryCancel(MotionHandle handle, bool checkIsInSequence = true);

		bool TryComplete(MotionHandle handle, bool checkIsInSequence = true);

		void Cancel(MotionHandle handle, bool checkIsInSequence = true);

		void Complete(MotionHandle handle, bool checkIsInSequence = true);

		void SetTime(MotionHandle handle, double time, bool checkIsInSequence = true);

		ref MotionData GetDataRef(MotionHandle handle, bool checkIsInSequence = true);

		ref ManagedMotionData GetManagedDataRef(MotionHandle handle, bool checkIsInSequence = true);

		void AddToSequence(MotionHandle handle, out double motionDuration);

		MotionDebugInfo GetDebugInfo(MotionHandle handle);

		void Reset();
	}
}
