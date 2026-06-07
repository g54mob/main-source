using System.IO;

namespace Simulator
{
	public struct SaveFileInfo
	{
		public readonly bool isValid;

		public readonly FileInfo fileInfo;

		public readonly ESaveType saveType;

		public readonly int shopLevel;

		public readonly float moneyAmount;

		public readonly string inGameTime;

		public SaveFileInfo(FileInfo fileInfo)
		{
			this.fileInfo = fileInfo;
			if (SaveManager.LoadSave(fileInfo.FullName, out var save))
			{
				isValid = true;
				saveType = save.saveType;
				shopLevel = save.globalState.shopLevel;
				moneyAmount = save.globalState.moneyAmount;
				inGameTime = save.globalState.dayTime.ToString();
			}
			else
			{
				isValid = false;
				saveType = ESaveType.MANUAL;
				shopLevel = 0;
				moneyAmount = 0f;
				inGameTime = null;
			}
		}
	}
}
