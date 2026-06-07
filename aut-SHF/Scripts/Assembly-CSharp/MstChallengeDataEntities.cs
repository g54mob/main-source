using System;
using System.Collections.Generic;

[Serializable]
public class MstChallengeDataEntities
{
	public eChallengeId challengeId;

	public eStageId stage;

	public string name;

	public string desc;

	public List<eWriterId> availableWriters;

	public int difficulty;

	public bool endless;

	public bool isHidden;

	public bool isTrial;

	public bool isEarly;

	public bool isOpen;

	public bool isEvent;

	public string imagePath;
}
