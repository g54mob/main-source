using Localization;

namespace App.Data
{
	public class BaseQuest : BaseUnlockedData
	{
		public string TaskType;

		public string Texts;

		public int Hard;

		public int Main;

		public int Reward;

		public virtual string GetScoreTextForEpoch()
		{
			return TextResources.GetString("Score") + " " + QuestLine.GetQuest(KeyName).GetScore() + " / 3";
		}

		public bool Is<T>() where T : BaseQuest
		{
			return this is T;
		}

		public T As<T>() where T : BaseQuest
		{
			return (T)this;
		}

		public virtual bool Init(object userData)
		{
			return false;
		}

		public virtual void Start()
		{
		}

		public virtual void End()
		{
			Logic.GetModel().RunTaskWhenTreeOpens = KeyName;
		}

		public virtual void ReInitConstructionArea(bool resetInOut = true)
		{
		}

		public virtual void OpenQuest()
		{
		}

		public virtual bool Update(BaseQuest refQuest)
		{
			return false;
		}

		public virtual int GetRewardFromMedal(int medal)
		{
			return Reward;
		}
	}
}
