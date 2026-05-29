using System;
using System.Collections.Generic;

[Serializable]
public class MstTutorialEntities
{
	public eTutorialId tutorialId;

	public eTutorialSectionId section;

	public eTipsType tipsType;

	public string title;

	public string padTitle;

	public string switchMouseTitle;

	public List<string> param1;

	public List<string> param2;

	public List<string> param3;

	public List<string> param4;

	public string imagePath;

	public string moviePath;

	public string mapPath;
}
