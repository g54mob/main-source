using System.Collections.Generic;
using UnityEngine;

public class LanguageText
{
	private static Dictionary<string, string> _english;

	private static Dictionary<string, string> _chinese;

	public static string GetText(string key)
	{
		if (_english == null)
		{
			Initialize();
		}
		Dictionary<string, string> dictionary = ((TextFontManager.GetLanguage() != TextFontManager.LanguageType.Mandarin) ? _english : _chinese);
		if (dictionary.ContainsKey(key))
		{
			return dictionary[key];
		}
		Debug.Log("Can't find key " + key);
		return "?" + key + "?";
	}

	private static void Initialize()
	{
		_english = new Dictionary<string, string>();
		_chinese = new Dictionary<string, string>();
		AddText("Start", "Start", "开始");
		AddText("Settings", "Settings", "设置");
		AddText("Quit", "Quit", "辞职");
		AddText("Resolution", "Resolution", "分辨率");
		AddText("Fullscreen", "Fullscreen", "全屏");
		AddText("Volume", "Volume", "体积");
		AddText("Music", "Music", "音乐");
		AddText("SFX", "SFX", "音效");
		AddText("Screen Effect", "Screen Effect", "屏幕效果");
		AddText("Pixel Font", "Pixel Font", "像素字体");
		AddText("PixelFontNote", "The game was designed for pixel font.", "该游戏是针对像素字体设计的。");
		AddText("Trash In Hole", "Trash In Hole", "洞里的垃圾");
		AddText("View Stats", "View Stats", "查看统计数据");
		AddText("Back", "Back", "后退");
		AddText("Game 1", "Game 1", "游戏 1");
		AddText("Game 2", "Game 2", "游戏 2");
		AddText("Game 3", "Game 3", "游戏 3");
		AddText("Extended Mode", "Extended Mode", "扩展模式");
		AddText("Relax Mode", "Relax Mode", "放松模式");
		AddText("Relax", "Relax", "放松");
		AddText("Extended", "Extended", "扩展");
		AddText("Demo", "Demo", "演示");
		AddText("FollowWishlist", "Follow \\ Wishlist -->", "关注 \\ 愿望清单 -->");
		AddText("FollowWishlist2", "Follow \\ Wishlist", "关注 \\ 愿望清单");
		AddText("Yes", "Yes", "是的");
		AddText("No", "No", "不");
		AddText("AreYouSureDelete", "Are you sure you want to delete?", "您确定要删除吗？");
		AddText("Close", "Close", "关闭");
		AddText("Endless", "Endless", "无尽");
		AddText("Main Menu", "Main Menu", "主菜单");
		AddText("Total", "Total", "全部的");
		AddText("Trash", "Trash", "");
		AddText("RP", "RP", "研究点");
		AddText("Y.S.", "Y.S.", "黄色碎片");
		AddText("B.S.", "B.S.", "蓝色碎片");
		AddText("R.S.", "R.S.", "红色碎片");
		AddText("Books", "Books", "图书");
		AddText("Quests", "Quests", "任务");
		AddText("NewHelpEntry", "A new entry has been added to the Help section.", "帮助部分添加了一个新条目。");
		AddText("FactoryBuildHelp", "Factory can now be built.", "现在可以建造工厂。");
		AddText("CatapultBuildHelp", "Catapult can now be built.", "现在可以建造弹射器了。");
		AddText("QuestCanComplete", "A new quest can be completed.", "可以完成新的任务。");
		AddText("GainedBlueShard", "Gained a blue shard. The upgrade tree can now be unlocked.", "获得蓝色碎片。升级树现已解锁。");
		AddText("Filled", "Filled", "已填充");
		AddText("min", "min", "分钟");
		AddText("Fill", "Fill", "充满");
		AddText("GainedBook", "Book found. More information is available in the Help section.", "找到书了。更多信息请参阅“帮助”部分。");
		AddText("", "", "");
		AddText("", "", "");
		AddText("", "", "");
		AddText("", "", "");
		AddText("Destroy", "Destroy", "破坏");
		AddText("Really", "Really", "真的");
		AddText("", "", "");
		AddText("", "", "");
		AddText("", "", "");
		AddText("", "", "");
		AddText("House", "House", "房子");
		AddText("Catapult", "Catapult", "弹射");
		AddText("Temple", "Temple", "寺庙");
		AddText("Helipad", "Helipad", "直升机停机坪");
		AddText("Cloud Seeder", "Cloud Seeder", "云播种机");
		AddText("Research Lab", "Research Lab", "研究实验室");
		AddText("Hangar", "Hangar", "机库");
		AddText("Training", "Training", "训练");
		AddText("Factory", "Factory", "工厂");
		AddText("Power", "Power", "力量");
		AddText("Compressor", "Compressor", "压缩机");
		AddText("CatapultLowDur", "A Catapult with low durability was destroyed.", "耐久度低的弹射器被摧毁。");
		AddText("HelicopterLowDur", "A Helipad with low durability was destroyed.", "耐久度较低的直升机停机坪被毁坏。");
		AddText("HouseLowDur", "A House with low durability was destroyed.", "耐久度低的房屋被摧毁了。");
		AddText("ResearchLowDur", "A Research Lab with low durability was destroyed.", "耐久度较低的研究实验室被摧毁。");
		AddText("HotAirBaloonLowDur", "A Hangar with low durability was destroyed.", "耐久度较低的机库被摧毁。");
		AddText("TrainingLowDur", "A Training with low durability was destroyed.", "耐久度低的训练被摧毁。");
		AddText("IndustryLowDur", "A Factory with low durability was destroyed.", "耐久度低的工厂被摧毁。");
		AddText("PowerLowDur", "A Power building with low durability was destroyed.", "一座耐久度低的发电建筑被摧毁。");
		AddText("CompressorLowDur", "A Compressor with low durability was destroyed.", "耐久度较低的压缩机被毁坏。");
		AddText("DroneLowDur", "A Cloud Seeder with low durability was destroyed.", "一架耐久度较低的云播种机被摧毁。");
		AddText("GenericLowDur", "A building with low durability was destroyed.", "耐久度低的建筑物被摧毁。");
		AddText("CatapultLowDurRelax", "A Catapult's durability reached zero and was reset.", "弹射器的耐久度达到零并被重置。");
		AddText("HelicopterLowDurRelax", "A Helipad's durability reached zero and was reset.", "直升机停机坪的耐久度达到零并被重置。");
		AddText("HouseLowDurRelax", "A House's durability reached zero and was reset.", "房屋的耐久度达到零并被重置。");
		AddText("ResearchLowDurRelax", "A Research Lab's durability reached zero and was reset.", "研究实验室的耐久度达到零并被重置。");
		AddText("HotAirBaloonLowDurRelax", "A Hangar's durability reached zero and was reset.", "机库的耐久度达到零并被重置。");
		AddText("TrainingLowDurRelax", "A Training's durability reached zero and was reset.", "训练的耐久度达到零并被重置。");
		AddText("IndustryLowDurRelax", "A Factory's durability reached zero and was reset.", "工厂的耐久度达到零并被重置。");
		AddText("PowerLowDurRelax", "A Power building's durability reached zero and was reset.", "电力建筑的耐久度达到零并被重置。");
		AddText("CompressorLowDurRelax", "A Compressor's durability reached zero and was reset.", "压缩机的耐久度达到零并被重置。");
		AddText("DroneLowDurRelax", "A Cloud Seeder's durability reached zero and was reset.", "云播种机的耐久度达到零并被重置。");
		AddText("GenericLowDurRelax", "A building's durability reached zero and was reset.", "建筑物的耐久度达到零并被重置。");
		AddText("", "", "");
		AddText("", "", "");
		AddText("", "", "");
		AddText("", "", "");
		AddText("EndDemoDescription", "This is the end of the demo.\nThanks a lot for playing!", "试玩版到此结束。\n非常感谢您的参与！");
		AddText("Ending1Description", "Congratulations! You've filled up the hole and reached the statue. But there must be a way to stop the monster.", "恭喜！你填满了洞，到达了雕像。不过肯定有办法阻止怪物。");
		AddText("Ending2Description", "Congratulations! You've filled the hole, reached the statue, and captured the monster. Thanks for playing!", "恭喜！你填满了洞，到达了雕像，并且抓住了怪物。感谢你的参与！");
		AddText("TimePlayed", "Time Played: ", "游玩時間：");
		AddText("Trash Manually Tossed", "Trash Manually Tossed", "手动丢弃的垃圾");
		AddText("Trash Peon Tossed", "Trash Peon Tossed", "扔垃圾的苦工");
		AddText("Cloud Clicked", "Cloud Clicked", "云点击");
		AddText("Cloud Destroyed", "Cloud Destroyed", "云毁了");
		AddText("Build Building", "Build Building", "建造建筑物");
		AddText("", "", "");
		AddText("", "", "");
		AddText("", "", "");
		AddText("", "", "");
		AddText("", "", "");
	}

	private static void AddText(string key, string en, string cn)
	{
		if (key != "")
		{
			_english.Add(key, en);
			_chinese.Add(key, cn);
		}
	}
}
