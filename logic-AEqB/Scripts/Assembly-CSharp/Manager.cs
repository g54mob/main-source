using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text.RegularExpressions;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Manager : MonoBehaviour
{
	public GameState gameState;

	public TestTMPExpansion gamelog;

	public TestTMPExpansion program;

	public string FileName = "test.lua";

	public string dataString;

	public TMP_InputField quest_text;

	public TMP_InputField str_text;

	public List<string> input_str;

	public List<string> output_str;

	private GlobalManager globalManager;

	public bool isCustomTest;

	public TMP_InputField[] fields;

	public int fontsize = 20;

	public Scrollbar[] scrolls;

	public Button story_btn;

	public int currentPanel;

	public int chapter;

	public bool level_solved;

	public HorizontalLayoutGroup panel_btn_layout;

	public int previous_chapter = 1;

	public Camera colored_cam;

	public Image[] colored_img;

	public TMP_Text[] colored_txt;

	public bool isDark;

	public Color lightblue;

	public Color darkblue;

	public Color[] error_color;

	public Color[] correct_color;

	public GameObject editor_savebutton;

	public GameObject editor_loadbutton;

	public GameObject editor_uploadbtn;

	public GameObject editor_testbtn;

	private int timecost;

	private string CustomTestString;

	private string sandbox_pre = "abc\nbbc";

	public List<string> sandbox_data;

	public bool fixScroll;

	public List<string> editor_result;

	public List<string> editor_result_in;

	private float deltaTime = 0.5f;

	private int maxii = 1;

	public GameObject test_obj;

	public Button play1;

	public Button play2;

	public Button play3;

	public Button step;

	public Button stop;

	public Button ispause;

	public List<string> previous_str = new List<string>();

	private float lastframe;

	private Stopwatch watch;

	private Stopwatch testw;

	public new_level_info editor_level;

	private int fontsize0;

	public List<Image> backs;

	private int firstframe = 2;

	private string test_input;

	private string test_output;

	private bool wasRun = true;

	private bool isStep;

	public int target_line;

	public List<line> lines = new List<line>();

	private string error_message = "";

	private string error_message_ch = "";

	public string out_text;

	public int running_test;

	private float finish_time;

	private bool nextTestCase;

	private int cases;

	private bool wasfocus;

	public List<string> editor_input;

	private string str;

	public int line_total;

	public string[] prog_str;

	[TextArea(100, 100)]
	public string prog;

	private bool[] prog_once;

	private string hint;

	public List<string> previous_prog;

	public List<int> previous_caret;

	public List<string> redo_prog;

	public List<int> redo_caret;

	public bool FixScrollProg;

	public int selectedLine = -1;

	public bool isUndo;

	public bool isPaste;

	public new_level_info editor_info;

	private bool customtest2;

	private void SetInteractable(bool b)
	{
		program.inputField.interactable = b;
		str_text.interactable = b;
	}

	private void Awake()
	{
		if (!UnityEngine.Object.FindObjectOfType<GlobalManager>())
		{
			SceneManager.LoadScene(0);
		}
		testw = new Stopwatch();
		testw.Start();
	}

	private void SetFontSize()
	{
		fontsize0 = Screen.height / 36;
		fontsize = fontsize0 * (globalManager.setting.fontsize + 2) / 5;
		TMP_InputField[] array = fields;
		foreach (TMP_InputField tMP_InputField in array)
		{
			if (tMP_InputField.gameObject.name == "IOInputField")
			{
				tMP_InputField.pointSize = fontsize0;
			}
			else
			{
				tMP_InputField.pointSize = fontsize;
			}
		}
	}

	private void Start()
	{
		globalManager = UnityEngine.Object.FindObjectOfType<GlobalManager>();
		if (globalManager != null)
		{
			FileName = globalManager.level.id;
		}
		else
		{
			SceneManager.LoadScene(0);
		}
		fields = UnityEngine.Object.FindObjectsOfType<TMP_InputField>();
		scrolls = UnityEngine.Object.FindObjectsOfType<Scrollbar>();
		SetFontSize();
		program.SetUp();
		gamelog.SetUp();
		quest_text.gameObject.GetComponent<TestTMPExpansion>().SetUp();
		str_text.gameObject.GetComponent<TestTMPExpansion>().SetUp();
		foreach (save_info datum in globalManager.sv.data)
		{
			if (datum.id == FileName)
			{
				currentPanel = datum.lastpanel;
			}
		}
		if (currentPanel == 0)
		{
			currentPanel = 1;
		}
		Load();
		if (globalManager.setting.language == 1)
		{
			quest_text.text = globalManager.level.title_ch + "\n" + globalManager.level.quest_ch;
		}
		else if (globalManager.setting.language == 2)
		{
			quest_text.text = globalManager.level.title_cht + "\n" + globalManager.level.quest_cht;
		}
		else if (globalManager.setting.language == 3)
		{
			quest_text.text = globalManager.level.title_jp + "\n" + globalManager.level.quest_jp;
		}
		else if (globalManager.setting.language == 0)
		{
			quest_text.text = globalManager.level.title_en + "\n" + globalManager.level.quest_en;
		}
		SetInteractable(b: true);
		if (globalManager.level.id == "editor")
		{
			quest_text.interactable = true;
			editor_loadbutton.SetActive(value: true);
			editor_savebutton.SetActive(value: true);
			editor_uploadbtn.SetActive(value: true);
			editor_testbtn.SetActive(value: true);
			globalManager.allowChineseInput = true;
			quest_text.text = globalManager.level.editor;
			program.txt.text = globalManager.level.editor_prog;
		}
		else
		{
			editor_loadbutton.SetActive(value: false);
			editor_savebutton.SetActive(value: false);
			editor_uploadbtn.SetActive(value: false);
			editor_testbtn.SetActive(value: false);
			NewTestCase();
			DisplayTestCase();
			globalManager.allowChineseInput = false;
		}
		if (globalManager.setting.theme)
		{
			TMP_Text[] array = colored_txt;
			for (int i = 0; i < array.Length; i++)
			{
				array[i].color = Color.white;
			}
			Image[] array2 = colored_img;
			for (int i = 0; i < array2.Length; i++)
			{
				array2[i].color = Color.black;
			}
			foreach (Image back in backs)
			{
				back.gameObject.SetActive(value: true);
			}
			isDark = true;
		}
		ResetProg();
		chapter = FileName[1] - 48;
		if (globalManager.level.id == "sandbox" || globalManager.level.id == "editor")
		{
			chapter = 10;
			if (globalManager.level.id == "editor")
			{
				gamelog.inputField.text = "Run your solution to generate test cases\n\nS - Save\nL - Load\nT - Test\nU - Upload to steamworkshop\n\nClick i button above to read detailed manual.";
			}
			if (globalManager.level.id == "editor" && !globalManager.newcustomlevel)
			{
				editor_info = globalManager.editor_chosen;
				if (editor_info.editor_prog != "")
				{
					program.inputField.text = editor_info.editor_prog;
					prog = editor_info.editor_prog;
				}
				if (editor_info.input != null && editor_info.input.Count > 0)
				{
					editor_result_in = editor_info.input;
					editor_result = editor_info.output;
				}
				Editor_QuestWriter();
			}
			return;
		}
		for (int j = 0; j < globalManager.sv.data.Count; j++)
		{
			if (globalManager.sv.data[j].id == FileName)
			{
				level_solved = globalManager.sv.data[j].solved;
			}
		}
		if (level_solved)
		{
			DisplayChallenge();
		}
	}

	private void Update()
	{
		if (Input.GetKeyDown(KeyCode.F1))
		{
			Run(1f);
		}
		if (Input.GetKeyDown(KeyCode.F2))
		{
			Run(0.1f);
		}
		if (Input.GetKeyDown(KeyCode.F3))
		{
			Run(-1f);
		}
		if (Input.GetKeyDown(KeyCode.F4))
		{
			PauseRun();
		}
		if (Input.GetKeyDown(KeyCode.F5))
		{
			Step();
		}
		if (Input.GetKeyDown(KeyCode.F6))
		{
			ResetProg();
		}
		if (Input.GetKeyDown(KeyCode.F7))
		{
			Hint();
		}
		if (Input.GetKeyDown(KeyCode.F8))
		{
			ChangeFont(5);
		}
		if (Input.GetKeyDown(KeyCode.F9))
		{
			ChangeFont(-5);
		}
		if (Input.GetKeyDown(KeyCode.F10))
		{
			ReturnToMenu();
		}
		if (Input.GetKeyDown(KeyCode.Escape) && !program.wasFocused && !gamelog.wasFocused && !wasfocus)
		{
			ReturnToMenu();
		}
		wasfocus = quest_text.isFocused || str_text.isFocused;
		if (firstframe > 0)
		{
			program.jumpToLine = 0;
			gamelog.jumpToLine = 0;
			firstframe--;
			panel_btn_layout.spacing = Screen.width / 500;
			panel_btn_layout.childForceExpandWidth = true;
		}
		if (gameState == GameState.Pause)
		{
			ispause.image.color = new Color(40f / 51f, 40f / 51f, 40f / 51f);
			play1.image.color = Color.white;
			play2.image.color = Color.white;
			play3.image.color = Color.white;
			step.image.color = Color.white;
			stop.image.color = Color.white;
		}
		else if (gameState == GameState.Run && isStep)
		{
			step.image.color = new Color(40f / 51f, 40f / 51f, 40f / 51f);
			play1.image.color = Color.white;
			play2.image.color = Color.white;
			play3.image.color = Color.white;
			ispause.image.color = Color.white;
			stop.image.color = Color.white;
		}
		else if (gameState == GameState.Run && deltaTime < 0f)
		{
			play3.image.color = new Color(40f / 51f, 40f / 51f, 40f / 51f);
			play1.image.color = Color.white;
			play2.image.color = Color.white;
			step.image.color = Color.white;
			ispause.image.color = Color.white;
			stop.image.color = Color.white;
		}
		else if (gameState == GameState.Run && deltaTime <= 0.1f)
		{
			play2.image.color = new Color(40f / 51f, 40f / 51f, 40f / 51f);
			play1.image.color = Color.white;
			play3.image.color = Color.white;
			step.image.color = Color.white;
			ispause.image.color = Color.white;
			stop.image.color = Color.white;
		}
		else if (gameState == GameState.Run && deltaTime <= 1f)
		{
			play1.image.color = new Color(40f / 51f, 40f / 51f, 40f / 51f);
			play3.image.color = Color.white;
			play2.image.color = Color.white;
			step.image.color = Color.white;
			ispause.image.color = Color.white;
			stop.image.color = Color.white;
		}
		else
		{
			play1.image.color = Color.white;
			play2.image.color = Color.white;
			play3.image.color = Color.white;
			step.image.color = Color.white;
			ispause.image.color = Color.white;
			stop.image.color = Color.white;
		}
		isUndo = false;
		isPaste = false;
		if (((Input.GetKey(KeyCode.LeftControl) || Input.GetKey(KeyCode.RightControl)) && Input.GetKeyDown(KeyCode.Z)) || (globalManager.isDev && Input.GetKeyDown(KeyCode.F11)))
		{
			if (previous_prog.Count > 1)
			{
				isUndo = true;
				redo_prog.Add(previous_prog[previous_prog.Count - 1]);
				redo_caret.Add(previous_caret[previous_caret.Count - 1]);
				previous_prog.RemoveAt(previous_prog.Count - 1);
				previous_caret.RemoveAt(previous_caret.Count - 1);
				program.inputField.text = previous_prog[previous_prog.Count - 1];
				program.inputField.caretPosition = previous_caret[previous_caret.Count - 1];
			}
		}
		else if ((((Input.GetKey(KeyCode.LeftControl) || Input.GetKey(KeyCode.RightControl)) && Input.GetKeyDown(KeyCode.Y)) || (globalManager.isDev && Input.GetKeyDown(KeyCode.F12))) && redo_prog.Count > 0)
		{
			isUndo = true;
			previous_prog.Add(redo_prog[redo_prog.Count - 1]);
			previous_caret.Add(redo_caret[redo_caret.Count - 1]);
			redo_prog.RemoveAt(redo_prog.Count - 1);
			redo_caret.RemoveAt(redo_caret.Count - 1);
			program.inputField.text = previous_prog[previous_prog.Count - 1];
			program.inputField.caretPosition = previous_caret[previous_caret.Count - 1];
		}
		if (gameState == GameState.Run)
		{
			if (deltaTime < 0f)
			{
				if (running_test < 5)
				{
					maxii = 20;
				}
				else if (running_test < 10)
				{
					maxii = 50;
				}
				else
				{
					maxii = 100;
				}
				maxii = 100000;
				watch = new Stopwatch();
				watch.Start();
			}
			else
			{
				maxii = 1;
			}
			int num = 0;
			if (Time.time - finish_time > deltaTime)
			{
				finish_time = Time.time;
				for (int i = 0; i < maxii; i++)
				{
					if (i > maxii)
					{
						UnityEngine.Debug.Log(i);
					}
					if (i % 100 == 99 && watch.ElapsedMilliseconds > 30)
					{
						UnityEngine.Debug.Log(Time.deltaTime);
						UnityEngine.Debug.Log(watch.ElapsedMilliseconds);
						UnityEngine.Debug.Log(i);
						break;
					}
					if (nextTestCase)
					{
						cases++;
						if (cases > 10)
						{
							deltaTime = -1f;
						}
						previous_str = new List<string>();
						running_test++;
						_ = isStep;
						if (running_test == input_str.Count)
						{
							if (isCustomTest)
							{
								DisplayCustomIOText(input_str[0], output_str[0], str);
							}
							else
							{
								DisplayIOText(running_test, input_str[running_test - 1], str, output_str[running_test - 1]);
								gamelog.inputField.text = out_text + "\n\nAccepted.";
								gamelog.jumpToLast = true;
							}
							gameState = GameState.Win;
							SetInteractable(b: true);
							if (globalManager != null && !isCustomTest)
							{
								if (!globalManager.solved.Contains(globalManager.level.id))
								{
									globalManager.solved.Add(globalManager.level.id);
								}
								for (int j = 0; j < globalManager.sv.data.Count; j++)
								{
									if (!(globalManager.sv.data[j].id == FileName))
									{
										continue;
									}
									if (lines.Count <= globalManager.sv.data[j].challenge_line || globalManager.sv.data[j].challenge_line <= 0)
									{
										if (lines.Count <= globalManager.level.min_lines)
										{
											globalManager.sv.data[j] = new save_info(globalManager.sv.data[j].id, globalManager.sv.data[j].solved, currentPanel, ch: true, lines.Count);
										}
										else
										{
											globalManager.sv.data[j] = new save_info(globalManager.sv.data[j].id, globalManager.sv.data[j].solved, currentPanel, globalManager.sv.data[j].challenge, lines.Count);
										}
									}
									else
									{
										globalManager.sv.data[j] = new save_info(globalManager.sv.data[j].id, globalManager.sv.data[j].solved, currentPanel, globalManager.sv.data[j].challenge, globalManager.sv.data[j].challenge_line);
									}
								}
								globalManager.Save();
								level_solved = true;
								DisplayChallenge();
							}
							Canvas.ForceUpdateCanvases();
							gamelog.jumpToLast = true;
							isCustomTest = false;
							UnityEngine.Debug.Log(testw.ElapsedMilliseconds);
							return;
						}
						out_text = "Test Case " + (running_test + 1) + "\n";
						out_text = out_text + "Input: " + input_str[running_test] + "\n";
						gamelog.inputField.text = out_text;
						gamelog.jumpToLast = true;
						out_text = out_text + "\n" + input_str[running_test];
						str = input_str[running_test];
						test_output = output_str[running_test];
						target_line = 0;
						timecost = 0;
						for (int k = 0; k < lines.Count; k++)
						{
							if (lines[k].once == 2)
							{
								lines[k].once = 1;
							}
							prog_once[lines[k].line_num] = false;
						}
						nextTestCase = false;
						if (isCustomTest)
						{
							DisplayCustomIOText(input_str[0], output_str[0], str);
						}
						else
						{
							DisplayIOText(running_test + 1, input_str[running_test], str, output_str[running_test]);
						}
						if (isDark)
						{
							str_text.image.color = Color.black;
						}
						else
						{
							str_text.image.color = Color.white;
						}
						Canvas.ForceUpdateCanvases();
						gamelog.jumpToLine = gamelog.txt.textInfo.lineCount - 1;
						program.jumpToLine = 0;
						continue;
					}
					while (target_line < lines.Count && lines[target_line].once == 2)
					{
						target_line++;
					}
					UnityEngine.Debug.Log(timecost);
					if (target_line >= lines.Count)
					{
						if (isCustomTest)
						{
							out_text += "\n\n";
							out_text = out_text + "Your Output: " + str + "\n";
							gamelog.inputField.text = out_text;
							gamelog.jumpToLast = true;
							if (isDark)
							{
								str_text.image.color = Color.black;
							}
							else
							{
								str_text.image.color = Color.white;
							}
							nextTestCase = true;
							return;
						}
						out_text += "\n\n";
						out_text = out_text + "Your Output: " + str + "\nExpected Output: " + output_str[running_test];
						gamelog.inputField.text = out_text;
						gamelog.jumpToLast = true;
						nextTestCase = true;
						if (isCustomTest)
						{
							DisplayCustomIOText(input_str[0], output_str[0], str);
						}
						else
						{
							DisplayIOText(running_test + 1, input_str[running_test], str, output_str[running_test]);
						}
						if (isStep)
						{
							gameState = GameState.Pause;
						}
						if (globalManager.level.id == "editor")
						{
							if (str != "error")
							{
								editor_result_in.Add(input_str[running_test]);
								editor_result.Add(str);
							}
							nextTestCase = true;
							continue;
						}
						if (str == test_output)
						{
							if (isDark)
							{
								str_text.image.color = correct_color[0];
							}
							else
							{
								str_text.image.color = correct_color[1];
							}
							continue;
						}
						UnityEngine.Debug.Log(str);
						string text = "";
						for (int l = 0; l < str.Length; l++)
						{
							text += (int)str[l];
						}
						UnityEngine.Debug.Log(text);
						UnityEngine.Debug.Log(test_output);
						text = "";
						for (int m = 0; m < test_output.Length; m++)
						{
							text += (int)test_output[m];
						}
						UnityEngine.Debug.Log(text);
						out_text += "\n\nWrong answer.";
						gamelog.inputField.text = out_text;
						gamelog.jumpToLast = true;
						gameState = GameState.Error;
						if (isDark)
						{
							str_text.image.color = error_color[0];
						}
						else
						{
							str_text.image.color = error_color[1];
						}
						SetInteractable(b: true);
						i = maxii;
						continue;
					}
					if (str.Length > 255)
					{
						gameState = GameState.Error;
						if (isDark)
						{
							str_text.image.color = error_color[0];
						}
						else
						{
							str_text.image.color = error_color[1];
						}
						out_text += "\n\nError: String length limit (255) exceeded.";
						if (isCustomTest)
						{
							DisplayCustomIOText(input_str[0], output_str[0], str);
						}
						else
						{
							DisplayIOText(running_test + 1, input_str[running_test], str, output_str[running_test]);
						}
						gamelog.inputField.text = out_text;
						gamelog.jumpToLast = true;
						SetInteractable(b: true);
						return;
					}
					if (timecost > 100000)
					{
						gameState = GameState.Error;
						if (isDark)
						{
							str_text.image.color = error_color[0];
						}
						else
						{
							str_text.image.color = error_color[1];
						}
						out_text += "\n\nError: Time limit (100000) exceeded.";
						if (isCustomTest)
						{
							DisplayCustomIOText(input_str[0], output_str[0], str);
						}
						else
						{
							DisplayIOText(running_test + 1, input_str[running_test], str, output_str[running_test]);
						}
						gamelog.inputField.text = out_text;
						gamelog.jumpToLast = true;
						SetInteractable(b: true);
						return;
					}
					if (out_text.Length > 10000)
					{
						out_text = out_text.Substring(out_text.IndexOf("\n") + 1);
					}
					timecost++;
					_ = lines[target_line].line_num;
					num = 0;
					bool flag = false;
					int num2 = 0;
					if (lines[target_line].left_position == 0)
					{
						if (str.Contains(lines[target_line].left))
						{
							flag = true;
							num2 = str.IndexOf(lines[target_line].left);
							if (num2 == 0)
							{
								str = str.Substring(num2 + lines[target_line].left.Length);
							}
							else
							{
								str = str.Substring(0, num2) + str.Substring(num2 + lines[target_line].left.Length);
							}
						}
					}
					else if (lines[target_line].left_position == 3)
					{
						if (str == lines[target_line].left)
						{
							flag = true;
							num2 = 0;
							str = "";
						}
					}
					else if (lines[target_line].left_position == 1)
					{
						if (str.StartsWith(lines[target_line].left))
						{
							flag = true;
							num2 = 0;
							str = str.Substring(lines[target_line].left.Length);
						}
					}
					else if (lines[target_line].left_position == 2 && str.EndsWith(lines[target_line].left))
					{
						flag = true;
						num2 = str.Length - lines[target_line].left.Length;
						str = str.Substring(0, num2);
					}
					if (flag)
					{
						SelectLine(lines[target_line].line_screen_num, 2);
						out_text = out_text + "\n    " + lines[target_line].display;
						if (lines[target_line].once == 1)
						{
							lines[target_line].once = 2;
							prog_once[lines[target_line].line_num] = true;
						}
						if (lines[target_line].right_position == 0)
						{
							if (num2 >= str.Length)
							{
								str += lines[target_line].right;
							}
							else
							{
								str = str.Substring(0, num2) + lines[target_line].right + str.Substring(num2);
							}
							target_line = 0;
						}
						else if (lines[target_line].right_position == 1)
						{
							str = lines[target_line].right + str;
							target_line = 0;
						}
						else if (lines[target_line].right_position == 2)
						{
							str += lines[target_line].right;
							target_line = 0;
						}
						else if (lines[target_line].right_position == 3)
						{
							str = lines[target_line].right;
							target_line = lines.Count;
						}
						out_text = out_text + "\n" + str;
						if (isStep)
						{
							gameState = GameState.Pause;
							maxii = 0;
						}
					}
					else
					{
						SelectLine(lines[target_line].line_screen_num, 1);
						target_line++;
					}
				}
				if (num == 0 && deltaTime > 0f)
				{
					finish_time -= deltaTime / 2f;
				}
				gamelog.inputField.text = out_text;
				gamelog.jumpToLast = true;
				if (isCustomTest)
				{
					DisplayCustomIOText(input_str[0], output_str[0], str);
				}
				else
				{
					DisplayIOText(running_test + 1, input_str[running_test], str, output_str[running_test]);
				}
			}
		}
		if (wasRun)
		{
			gamelog.jumpToLast = true;
			wasRun = false;
		}
		if (gameState == GameState.Run)
		{
			gamelog.jumpToLast = true;
			wasRun = true;
		}
	}

	public void DisplayTestCase()
	{
		string text = "\n\n";
		if (globalManager.level.id == "sandbox")
		{
			return;
		}
		text = ((globalManager.setting.language == 1) ? (text + "样例:") : ((globalManager.setting.language == 2) ? (text + "樣例:") : ((globalManager.setting.language != 3) ? (text + "Example:") : (text + "入出力例:"))));
		foreach (string item in globalManager.level.example_input)
		{
			for (int i = 0; i < input_str.Count; i++)
			{
				if (input_str[i] == item)
				{
					text = text + "\nInput:  " + input_str[i] + "\n";
					text = text + "Output: " + output_str[i];
				}
			}
		}
		quest_text.text += text;
	}

	public void DisplayChallenge()
	{
		string text = "";
		if (globalManager.level.id == "sandbox" || globalManager.level.id == "editor")
		{
			return;
		}
		if (globalManager.setting.language == 1)
		{
			text = globalManager.level.title_ch + "\n" + globalManager.level.quest_ch + "\n挑战目标: ";
			text = text + "最多" + globalManager.level.min_lines + "行。";
			for (int i = 0; i < globalManager.sv.data.Count; i++)
			{
				if (globalManager.sv.data[i].id == FileName && globalManager.sv.data[i].challenge_line < globalManager.level.min_lines)
				{
					text += " （已完成）";
				}
			}
		}
		else if (globalManager.setting.language == 2)
		{
			text = globalManager.level.title_cht + "\n" + globalManager.level.quest_cht + "\n挑戰目標：";
			text = text + "最多" + globalManager.level.min_lines + "行。";
			for (int j = 0; j < globalManager.sv.data.Count; j++)
			{
				if (globalManager.sv.data[j].id == FileName && globalManager.sv.data[j].challenge_line < globalManager.level.min_lines)
				{
					text += " （已完成）";
				}
			}
		}
		else if (globalManager.setting.language == 3)
		{
			text = globalManager.level.title_jp + "\n" + globalManager.level.quest_jp + "\n追加の目的：";
			text = text + "最大" + globalManager.level.min_lines + "ライン。";
			for (int k = 0; k < globalManager.sv.data.Count; k++)
			{
				if (globalManager.sv.data[k].id == FileName && globalManager.sv.data[k].challenge_line < globalManager.level.min_lines)
				{
					text += " （完成）";
				}
			}
		}
		else if (globalManager.setting.language == 0)
		{
			text = globalManager.level.title_en + "\n" + globalManager.level.quest_en + "\nChallenge: ";
			text = ((globalManager.level.min_lines != 1) ? (text + "At most " + globalManager.level.min_lines + " lines.") : (text + "At most " + globalManager.level.min_lines + " line."));
			for (int l = 0; l < globalManager.sv.data.Count; l++)
			{
				if (globalManager.sv.data[l].id == FileName && globalManager.sv.data[l].challenge_line < globalManager.level.min_lines)
				{
					text += " (Comeplete)";
				}
			}
		}
		quest_text.text = text;
		DisplayTestCase();
	}

	public void DisplayIOText(int c, string in_str, string now_str, string out_str)
	{
		string text = "";
		text += "Test Case ";
		text = text + c + ":";
		if (c < 10)
		{
			text += " ";
		}
		if (c < 100)
		{
			text += " ";
		}
		if (c < 1000)
		{
			text += " ";
		}
		text = text + "  " + in_str + "\n";
		text = text + "Expected Output: " + out_str + "\n";
		if (now_str != "#")
		{
			text = text + "Current String:  " + now_str;
		}
		str_text.text = text;
	}

	public void DisplayCustomIOText(string in_str, string out_str, string now_str)
	{
		string text = "";
		text = text + "Custom Input:    " + in_str + "\n";
		text = text + "Expected Output: " + out_str + "\n";
		if (now_str != "#")
		{
			text = text + "Current String:  " + now_str;
		}
		str_text.text = text;
	}

	private void GenerateTestCase(int depth, int mindepth, int maxdepth, string range, string split, int split_n, string now)
	{
		if (depth >= mindepth && split_n == split.Length)
		{
			editor_input.Add(now);
		}
		if (depth < maxdepth)
		{
			for (int i = 0; i < range.Length; i++)
			{
				GenerateTestCase(depth + 1, mindepth, maxdepth, range, split, split_n, now + range[i]);
			}
		}
		if (depth >= mindepth && depth <= maxdepth && split_n < split.Length)
		{
			GenerateTestCase(0, mindepth, maxdepth, range, split, split_n + 1, now + split[split_n]);
		}
	}

	private void NewTestCase()
	{
		if (isCustomTest)
		{
			string item = "Invalid Input";
			for (int i = 0; i < globalManager.level.input.Count; i++)
			{
				if (globalManager.level.input[i] == CustomTestString)
				{
					item = globalManager.level.output[i];
				}
			}
			if (globalManager.level.id == "editor")
			{
				item = "";
			}
			input_str = new List<string>();
			output_str = new List<string>();
			input_str.Add(CustomTestString);
			output_str.Add(item);
			DisplayCustomIOText(CustomTestString, output_str[0], "#");
		}
		else if (globalManager.level.id == "editor")
		{
			if (firstframe > 0)
			{
				input_str = new List<string>();
				output_str = new List<string>();
				input_str.Add("abc");
				output_str.Add("bbc");
				return;
			}
			string[] array = new string[3] { "1", "7", "abc" };
			if (program.txt.text.StartsWith("#"))
			{
				array = program.txt.text.Substring(1, program.txt.text.IndexOf("\n") - 1).Split(' ');
			}
			int num = 1;
			int num2 = 7;
			string text = "abc";
			string split = "";
			try
			{
				num = Convert.ToInt32(array[0]);
				num2 = Convert.ToInt32(array[1]);
				text = array[2];
				if (num2 > 20)
				{
					num2 = 20;
				}
				if (num < 1)
				{
					num = 1;
				}
				if (array.Length >= 4)
				{
					split = array[3];
				}
			}
			catch
			{
				num = 1;
				num2 = 7;
				text = "abc";
				split = "";
			}
			editor_input = new List<string>();
			UnityEngine.Debug.Log(num + " " + num2 + " " + text);
			GenerateTestCase(0, num, num2, text, split, 0, "");
			input_str = editor_input;
			output_str = new List<string>();
			Editor_QuestReader();
			for (int j = 0; j < editor_info.example_input.Count; j++)
			{
				for (int k = 0; k < input_str.Count; k++)
				{
					if (editor_info.example_input[j] == input_str[k])
					{
						string value = input_str[k];
						input_str[k] = input_str[j];
						input_str[j] = value;
					}
				}
			}
			for (int l = editor_info.example_input.Count; l < input_str.Count; l++)
			{
				int index = UnityEngine.Random.Range(editor_info.example_input.Count, input_str.Count);
				string value2 = input_str[index];
				input_str[index] = input_str[l];
				input_str[l] = value2;
			}
			for (int m = 0; m < input_str.Count; m++)
			{
				output_str.Add("");
			}
			editor_result = new List<string>();
			editor_result_in = new List<string>();
		}
		else if (globalManager.level.id == "sandbox")
		{
			input_str = new List<string>();
			output_str = new List<string>();
			for (int n = 0; n < sandbox_data.Count; n++)
			{
				if (n % 2 == 0)
				{
					input_str.Add(sandbox_data[n]);
				}
				else
				{
					output_str.Add(sandbox_data[n]);
				}
			}
			DisplayIOText(1, input_str[0], "#", output_str[0]);
		}
		else
		{
			for (int num3 = 0; num3 < globalManager.level.input.Count; num3++)
			{
				globalManager.level.input[num3] = Regex.Replace(globalManager.level.input[num3], "[^ -~]", "");
			}
			for (int num4 = 0; num4 < globalManager.level.output.Count; num4++)
			{
				globalManager.level.output[num4] = Regex.Replace(globalManager.level.output[num4], "[^ -~]", "");
			}
			input_str = globalManager.level.input;
			output_str = globalManager.level.output;
			DisplayIOText(1, input_str[0], "#", output_str[0]);
		}
	}

	public void Run(float dt)
	{
		SetInteractable(b: false);
		isStep = false;
		deltaTime = dt;
		fixScroll = true;
		FixScrollProg = true;
		maxii = 1;
		cases = 0;
		if (gameState == GameState.Run)
		{
			return;
		}
		if (gameState == GameState.Pause)
		{
			gameState = GameState.Run;
			return;
		}
		lines = new List<line>();
		UnselectLine();
		Save();
		if (!Analysis())
		{
			gamelog.inputField.text = error_message;
			gamelog.jumpToLast = true;
			SetInteractable(b: true);
			gameState = GameState.Error;
		}
		else
		{
			program.jumpToLine = 0;
			NewTestCase();
			out_text = "";
			running_test = -1;
			nextTestCase = true;
			finish_time = Time.time - 1f;
			gameState = GameState.Run;
		}
	}

	private bool Analysis()
	{
		error_message = "";
		prog = program.inputField.text;
		prog = prog.Replace("\r", "");
		prog_str = prog.Split('\n');
		prog_once = new bool[prog_str.Length];
		line_total = prog_str.Length;
		string[] array = program.linenum.text.Replace(" ", "").Split('\n');
		int i = 0;
		for (int j = 0; j < prog_str.Length; j++)
		{
			prog_once[j] = false;
		}
		int num = 0;
		for (int k = 0; k < prog_str.Length; k++)
		{
			string input = prog_str[k];
			input = Regex.Replace(input, "[\u200b\u200c\u200d\u2060\ufeff]", "");
			if (input.IndexOf("#") != -1)
			{
				input = input.Substring(0, input.IndexOf("#"));
			}
			string text = Regex.Replace(input, "[^\0-\u007f]", "");
			if (input != text)
			{
				for (; array[i] == ""; i++)
				{
				}
				error_message = "Line " + (num + 1) + ": Non-ascii characters can only be used as commentry";
				SelectErrorLine(i);
				return false;
			}
			input = text;
			input = Regex.Replace(text, "[^!-~]", "");
			if (Regex.Matches(input, "=").Count == 1)
			{
				for (; array[i] == ""; i++)
				{
				}
				num++;
				string ss = prog_str[k];
				string text2 = input.Substring(0, input.IndexOf("="));
				string text3 = input.Substring(input.IndexOf("=") + 1);
				int t = 0;
				int ll = 0;
				int rr = 0;
				int num2 = 0;
				if (globalManager.level.chapter >= 2 && globalManager.level.chapter != 6)
				{
					while (text2.StartsWith("("))
					{
						text2 = text2.Substring(1);
						num2++;
						if (num2 > 1)
						{
							error_message = "Line " + num + ": Multiple keywords";
							SelectErrorLine(i);
							return false;
						}
						if ((text2.IndexOf("(") < text2.IndexOf(")") && text2.IndexOf("(") != -1) || text2.IndexOf(")") == -1)
						{
							error_message = "Line " + num + ": '(' and ')' mismatch";
							SelectErrorLine(i);
							return false;
						}
						string text4 = text2.Substring(0, text2.IndexOf(")"));
						if (text4 == "start")
						{
							if (globalManager.level.chapter < 3)
							{
								error_message = "Line " + num + ": Unknown keyword " + text4;
								SelectErrorLine(i);
								return false;
							}
							ll = 1;
						}
						if (text4 == "end")
						{
							if (globalManager.level.chapter < 3)
							{
								error_message = "Line " + num + ": Unknown keyword " + text4;
								SelectErrorLine(i);
								return false;
							}
							ll = 2;
						}
						if (text4 == "once")
						{
							if (globalManager.level.chapter < 4)
							{
								error_message = "Line " + num + ": Unknown keyword " + text4;
								SelectErrorLine(i);
								return false;
							}
							t = 1;
						}
						if (text4 == "return")
						{
							if (globalManager.level.chapter >= 2)
							{
								error_message = "Line " + num + ": Keyword 'return' can only be on the right";
								SelectErrorLine(i);
								return false;
							}
							error_message = "Line " + num + ": Unknown keyword " + text4;
							SelectErrorLine(i);
							return false;
						}
						if (text4 != "start" && text4 != "end" && text4 != "once" && text4 != "return")
						{
							error_message = "Line " + num + ": Unknown keyword " + text4;
							SelectErrorLine(i);
							return false;
						}
						text2 = text2.Substring(text2.IndexOf(")") + 1);
					}
					if (text2.Contains("(") || text2.Contains(")"))
					{
						error_message = "Line " + num + ": Found '(' and ')' at wrong position";
						SelectErrorLine(i);
						return false;
					}
					num2 = 0;
					while (text3.StartsWith("("))
					{
						num2++;
						text3 = text3.Substring(1);
						if (num2 > 1)
						{
							error_message = "Line " + num + ": Multiple keywords";
							SelectErrorLine(i);
							return false;
						}
						if ((text3.IndexOf("(") < text3.IndexOf(")") && text3.IndexOf("(") != -1) || text3.IndexOf(")") == -1)
						{
							error_message = "Line " + num + ": '(' and ')' mismatch";
							return false;
						}
						string text5 = text3.Substring(0, text3.IndexOf(")"));
						if (text5 == "start")
						{
							if (globalManager.level.chapter < 3)
							{
								error_message = "Line " + num + ": Unknown keyword " + text5;
								SelectErrorLine(i);
								return false;
							}
							rr = 1;
						}
						if (text5 == "end")
						{
							if (globalManager.level.chapter < 3)
							{
								error_message = "Line " + num + ": Unknown keyword " + text5;
								SelectErrorLine(i);
								return false;
							}
							rr = 2;
						}
						if (text5 == "once")
						{
							if (globalManager.level.chapter >= 4)
							{
								error_message = "Line " + num + ": Keyword 'once' can only be on the left";
								SelectErrorLine(i);
								return false;
							}
							error_message = "Line " + num + ": Unknown keyword " + text5;
							SelectErrorLine(i);
							return false;
						}
						if (text5 == "return")
						{
							if (globalManager.level.chapter < 2)
							{
								error_message = "Line " + num + ": Unknown keyword " + text5;
								SelectErrorLine(i);
								return false;
							}
							rr = 3;
						}
						if (text5 != "start" && text5 != "end" && text5 != "once" && text5 != "return")
						{
							error_message = "Line " + num + ": Unknown keyword " + text5;
							SelectErrorLine(i);
							return false;
						}
						text3 = text3.Substring(text3.IndexOf(")") + 1);
					}
					if (text3.Contains("(") || text3.Contains(")"))
					{
						error_message = "Line " + num + ": Found '(' and ')' at wrong position";
						SelectErrorLine(i);
						return false;
					}
				}
				line item = new line(text2, text3, ss, t, ll, rr, k, i);
				i++;
				lines.Add(item);
			}
			else
			{
				if (Regex.Matches(input, "=").Count >= 2)
				{
					error_message = "Line " + (num + 1) + ": Two or more '=' found in a line";
					SelectErrorLine(i);
					return false;
				}
				if (Regex.Matches(input, "=").Count == 0 && input.Length > 0)
				{
					error_message = "Line " + (num + 1) + ": No '=' found in a line";
					SelectErrorLine(i);
					return false;
				}
			}
		}
		return true;
	}

	public void UnselectLine()
	{
		program.colored_lines = new Dictionary<int, int>();
		selectedLine = -1;
		program.linenum_update = 2;
		if (gameState == GameState.Error)
		{
			gameState = GameState.Program;
		}
	}

	public void PauseRun()
	{
		if (gameState == GameState.Run)
		{
			gameState = GameState.Pause;
		}
	}

	public void Step()
	{
		Run(-1f);
		isStep = true;
	}

	public void ResetProg()
	{
		UnselectLine();
		if (globalManager.level.id == "sandbox")
		{
			NewTestCase();
			DisplayIOText(1, input_str[0], "#", output_str[0]);
			if (isDark)
			{
				str_text.image.color = Color.black;
			}
			else
			{
				str_text.image.color = Color.white;
			}
			gameState = GameState.Program;
			SetInteractable(b: true);
			return;
		}
		if (globalManager.level.id == "editor")
		{
			NewTestCase();
			DisplayIOText(1, input_str[0], "#", output_str[0]);
			if (isDark)
			{
				str_text.image.color = Color.black;
			}
			else
			{
				str_text.image.color = Color.white;
			}
			gameState = GameState.Program;
			SetInteractable(b: true);
			return;
		}
		if (customtest2)
		{
			AddCustomTest();
		}
		if (isCustomTest)
		{
			DisplayCustomIOText(CustomTestString, output_str[0], "#");
		}
		else
		{
			NewTestCase();
			DisplayIOText(1, input_str[0], "#", output_str[0]);
		}
		if (isDark)
		{
			str_text.image.color = Color.black;
		}
		else
		{
			str_text.image.color = Color.white;
		}
		gameState = GameState.Program;
		SetInteractable(b: true);
		previous_prog.Add(program.inputField.text);
		previous_caret.Add(program.inputField.caretPosition);
	}

	public void OnEditProg()
	{
		if (gameState == GameState.Program && !isUndo)
		{
			if (isPaste)
			{
				previous_caret.RemoveAt(previous_caret.Count - 1);
				previous_prog.RemoveAt(previous_prog.Count - 1);
			}
			program.inputField.text = program.inputField.text.Replace("\v", "\n");
			previous_prog.Add(program.inputField.text);
			previous_caret.Add(program.inputField.caretPosition);
			redo_prog = new List<string>();
			redo_caret = new List<int>();
			isPaste = true;
		}
	}

	public void SelectLine(int i, int type)
	{
		program.colored_lines = new Dictionary<int, int>();
		for (int j = 0; j < prog_str.Length; j++)
		{
			if (j == i)
			{
				if (isDark)
				{
					program.colored_lines.Add(i, type);
				}
				else
				{
					program.colored_lines.Add(i, type);
				}
			}
			else if (prog_once[j])
			{
				program.colored_lines.Add(j, 4);
			}
		}
		selectedLine = i;
		program.jumpToLine = i;
		program.linenum_update = 2;
	}

	public void ReturnToMenu()
	{
		Save();
		SceneManager.LoadScene(0);
	}

	public void SelectErrorLine(int i)
	{
		SelectLine(i, 3);
	}

	public void Hint()
	{
		ResetProg();
		isCustomTest = false;
		UnityEngine.Debug.Log(chapter);
		if (chapter == 10)
		{
			globalManager.OpenPDF("editor.pdf");
		}
		if (chapter <= 6)
		{
			if (globalManager.setting.language == 0)
			{
				globalManager.OpenPDF("CourseReport" + chapter + ".pdf");
			}
			else if (globalManager.setting.language == 1)
			{
				globalManager.OpenPDF("CourseReport" + chapter + "CHS.pdf");
			}
			else if (globalManager.setting.language == 2)
			{
				globalManager.OpenPDF("CourseReport" + chapter + "CHT.pdf");
			}
			else if (globalManager.setting.language == 3)
			{
				globalManager.OpenPDF("CourseReport" + chapter + "JP.pdf");
			}
		}
	}

	public void Save()
	{
		UnselectLine();
		if (!Directory.Exists(Application.dataPath + "/save/" + globalManager.steamManager.PlayerSteamIdString + "/" + globalManager.setting.saveslot + "/"))
		{
			Directory.CreateDirectory(Application.dataPath + "/save/" + globalManager.steamManager.PlayerSteamIdString + "/" + globalManager.setting.saveslot + "/");
		}
		FileInfo fileInfo = new FileInfo(Application.dataPath + "/save/" + globalManager.steamManager.PlayerSteamIdString + "/" + globalManager.setting.saveslot + "/" + FileName + currentPanel + ".sav");
		StreamWriter streamWriter;
		if (!fileInfo.Exists)
		{
			streamWriter = fileInfo.CreateText();
		}
		else
		{
			fileInfo.Delete();
			streamWriter = fileInfo.CreateText();
		}
		streamWriter.Write(program.inputField.text);
		streamWriter.Close();
		for (int i = 0; i < globalManager.sv.data.Count; i++)
		{
			if (globalManager.sv.data[i].id == FileName)
			{
				globalManager.sv.data[i] = new save_info(globalManager.sv.data[i].id, globalManager.sv.data[i].solved, currentPanel, globalManager.sv.data[i].challenge, globalManager.sv.data[i].challenge_line);
				globalManager.Save();
			}
		}
	}

	public void Load()
	{
		string path = Application.dataPath + "/save/" + globalManager.steamManager.PlayerSteamIdString + "/" + globalManager.setting.saveslot + "/" + FileName + currentPanel + ".sav";
		if (File.Exists(path))
		{
			StreamReader streamReader = File.OpenText(path);
			program.inputField.text = streamReader.ReadToEnd();
			prog = program.inputField.text;
			streamReader.Close();
			return;
		}
		program.inputField.text = "";
		if (FileName == "c1_1_atob" && currentPanel == 1)
		{
			program.inputField.text = "a=b";
			if (globalManager.setting.language == 0)
			{
				gamelog.inputField.text = "Click button \"i\" above (hotkey: F7) to open user manual.";
			}
			if (globalManager.setting.language == 1)
			{
				gamelog.inputField.text = "点击上方的\"i\"按钮(hotkey: F7)打开用户手册。";
			}
			if (globalManager.setting.language == 2)
			{
				gamelog.inputField.text = "點擊上方的\"i\"按鈕(hotkey: F7)打開用戶手冊";
			}
		}
		if (FileName == "c2_1_hello" && currentPanel == 1)
		{
			program.inputField.text = "a=(return)helloworld";
			if (globalManager.setting.language == 0)
			{
				gamelog.inputField.text = "Click button \"i\" above (hotkey: F7) to open user manual.\nUser manual is updated at the start of each chapter.";
			}
			if (globalManager.setting.language == 1)
			{
				gamelog.inputField.text = "点击上方的\"i\"按钮(hotkey: F7)打开用户手册。\n每章开始时，用户手册會有內容更新。";
			}
			if (globalManager.setting.language == 2)
			{
				gamelog.inputField.text = "點擊上方的\"i\"按鈕(hotkey: F7)打開用戶手冊。\n每章開始時，用戶手冊會有內容更新。";
			}
		}
		if (FileName == "c3_1_Remove" && currentPanel == 1)
		{
			program.inputField.text = "(start)a=";
		}
		if (FileName == "c4_1_hello2" && currentPanel == 1)
		{
			program.inputField.text = "(once)=(start)hello";
		}
		prog = program.inputField.text;
	}

	public void Editor_QuestReader()
	{
		string text = quest_text.text;
		try
		{
			text = text.Replace("\r\n", "\n");
			string[] array = Regex.Split(text, "\n\n");
			for (int i = 0; i < array.Length; i++)
			{
				string[] array2 = array[i].Split('\n');
				if (array2[0] == "id" && array2.Length >= 2)
				{
					editor_info.id = array2[1];
				}
				if (array2[0] == "title" && array2.Length >= 2)
				{
					editor_info.title_en = array2[1];
				}
				if (array2[0] == "title_en" && array2.Length >= 2)
				{
					editor_info.title_en = array2[1];
				}
				if (array2[0] == "title_chs" && array2.Length >= 2)
				{
					editor_info.title_ch = array2[1];
				}
				if (array2[0] == "title_cht" && array2.Length >= 2)
				{
					editor_info.title_cht = array2[1];
				}
				if (array2[0] == "title_jp" && array2.Length >= 2)
				{
					editor_info.title_jp = array2[1];
				}
				if (array2[0] == "line" && array2.Length >= 2)
				{
					editor_info.min_lines = Convert.ToInt32(array2[1]);
				}
				if (array2[0] == "chapter" && array2.Length >= 2)
				{
					editor_info.chapter = Convert.ToInt32(array2[1]);
				}
				if (array2[0] == "quest" && array2.Length >= 2)
				{
					string text2 = "";
					for (int j = 1; j < array2.Length; j++)
					{
						text2 = text2 + array2[j] + "\n";
					}
					text2 = text2.Remove(text2.Length - 1);
					editor_info.quest_en = text2;
				}
				if (array2[0] == "quest_en" && array2.Length >= 2)
				{
					string text3 = "";
					for (int k = 1; k < array2.Length; k++)
					{
						text3 = text3 + array2[k] + "\n";
					}
					text3 = text3.Remove(text3.Length - 1);
					editor_info.quest_en = text3;
				}
				if (array2[0] == "quest_chs" && array2.Length >= 2)
				{
					string text4 = "";
					for (int l = 1; l < array2.Length; l++)
					{
						text4 = text4 + array2[l] + "\n";
					}
					text4 = text4.Remove(text4.Length - 1);
					editor_info.quest_ch = text4;
				}
				if (array2[0] == "quest_cht" && array2.Length >= 2)
				{
					string text5 = "";
					for (int m = 1; m < array2.Length; m++)
					{
						text5 = text5 + array2[m] + "\n";
					}
					text5 = text5.Remove(text5.Length - 1);
					editor_info.quest_cht = text5;
				}
				if (array2[0] == "quest_jp" && array2.Length >= 2)
				{
					string text6 = "";
					for (int n = 1; n < array2.Length; n++)
					{
						text6 = text6 + array2[n] + "\n";
					}
					text6 = text6.Remove(text6.Length - 1);
					editor_info.quest_jp = text6;
				}
				if (array2[0] == "example_input" && array2.Length >= 2)
				{
					editor_info.example_input.Clear();
					for (int num = 1; num < array2.Length; num++)
					{
						editor_info.example_input.Add(array2[num]);
					}
				}
			}
		}
		catch
		{
			UnityEngine.Debug.Log("invalid");
			gamelog.inputField.text = "Invalid parameter";
		}
	}

	public void Editor_QuestWriter()
	{
		string text = "id\n" + editor_info.id + "\n\ntitle\n" + editor_info.title_en + "\n\nquest\n" + editor_info.quest_en + "\n\nline\n" + editor_info.min_lines + "\n\nchapter\n" + editor_info.chapter + "\n\nexample_input";
		foreach (string item in editor_info.example_input)
		{
			text = text + "\n" + item;
		}
		quest_text.text = text;
	}

	public void ChangePanel(int i)
	{
		UnityEngine.Debug.Log("change" + i);
		switch (i)
		{
		case 100:
		{
			Editor_QuestReader();
			string text4 = Application.dataPath + "/custom/";
			if (!Directory.Exists(text4))
			{
				Directory.CreateDirectory(text4);
			}
			string text5 = text4 + editor_info.id + ".a2b";
			UnityEngine.Debug.Log(text5);
			FileInfo fileInfo2 = new FileInfo(text5);
			StreamWriter streamWriter2;
			if (!fileInfo2.Exists)
			{
				streamWriter2 = fileInfo2.CreateText();
			}
			else
			{
				fileInfo2.Delete();
				streamWriter2 = fileInfo2.CreateText();
			}
			editor_info.editor = quest_text.text;
			editor_info.input = editor_result_in;
			editor_info.output = editor_result;
			editor_info.editor_prog = program.inputField.text;
			streamWriter2.Write(JsonUtility.ToJson(editor_info, prettyPrint: true));
			streamWriter2.Close();
			globalManager.RefreshCustom();
			break;
		}
		case 200:
		{
			Editor_QuestReader();
			string text3 = string.Concat(Application.dataPath + "/custom/", editor_info.id, ".a2b");
			UnityEngine.Debug.Log(text3);
			if (new FileInfo(text3).Exists)
			{
				StreamReader streamReader = File.OpenText(text3);
				string json = streamReader.ReadToEnd();
				editor_info = JsonUtility.FromJson<new_level_info>(json);
				quest_text.text = editor_info.editor;
				if (editor_info.editor_prog != "")
				{
					program.inputField.text = editor_info.editor_prog;
					prog = editor_info.editor_prog;
				}
				if (editor_info.input != null && editor_info.input.Count > 0)
				{
					editor_result_in = editor_info.input;
					editor_result = editor_info.output;
				}
				Editor_QuestWriter();
				streamReader.Close();
			}
			break;
		}
		case 300:
		{
			if (editor_result.Count == 0)
			{
				gamelog.inputField.text = "Run your program to generate test cases.";
				break;
			}
			Editor_QuestReader();
			string text6 = Application.dataPath + "/custom/";
			if (!Directory.Exists(text6))
			{
				Directory.CreateDirectory(text6);
			}
			string text7 = text6 + editor_info.id + ".a2b";
			UnityEngine.Debug.Log(text7);
			FileInfo fileInfo3 = new FileInfo(text7);
			StreamWriter streamWriter3;
			if (!fileInfo3.Exists)
			{
				streamWriter3 = fileInfo3.CreateText();
			}
			else
			{
				fileInfo3.Delete();
				streamWriter3 = fileInfo3.CreateText();
			}
			editor_info.editor = quest_text.text;
			editor_info.input = editor_result_in;
			editor_info.output = editor_result;
			editor_info.editor_prog = program.inputField.text;
			globalManager.TryUpload(editor_info);
			streamWriter3.Write(JsonUtility.ToJson(editor_info, prettyPrint: true));
			streamWriter3.Close();
			globalManager.RefreshCustom();
			break;
		}
		case 400:
		{
			if (editor_result.Count == 0)
			{
				gamelog.inputField.text = "Run your program to generate test cases.";
				break;
			}
			Editor_QuestReader();
			string text = Application.dataPath + "/custom/";
			if (!Directory.Exists(text))
			{
				Directory.CreateDirectory(text);
			}
			string text2 = text + editor_info.id + ".a2b";
			UnityEngine.Debug.Log(text2);
			FileInfo fileInfo = new FileInfo(text2);
			StreamWriter streamWriter;
			if (!fileInfo.Exists)
			{
				streamWriter = fileInfo.CreateText();
			}
			else
			{
				fileInfo.Delete();
				streamWriter = fileInfo.CreateText();
			}
			editor_info.editor = quest_text.text;
			editor_info.input = editor_result_in;
			editor_info.output = editor_result;
			editor_info.editor_prog = program.inputField.text;
			streamWriter.Write(JsonUtility.ToJson(editor_info, prettyPrint: true));
			streamWriter.Close();
			globalManager.RefreshCustom();
			globalManager.level = editor_info;
			globalManager.FillEmpty();
			SceneManager.LoadScene(1);
			break;
		}
		default:
			ResetProg();
			Save();
			currentPanel = i;
			Load();
			previous_prog = new List<string>();
			previous_caret = new List<int>();
			previous_prog.Add(program.inputField.text);
			previous_caret.Add(program.inputField.caretPosition);
			redo_prog = new List<string>();
			redo_caret = new List<int>();
			break;
		}
	}

	public void ChangeFont(int delta)
	{
		if (delta < 0 && globalManager.setting.fontsize > 1)
		{
			globalManager.setting.fontsize--;
		}
		if (delta > 0 && globalManager.setting.fontsize < 6)
		{
			globalManager.setting.fontsize++;
		}
		SetFontSize();
	}

	public void AddCustomTest()
	{
		if (!customtest2)
		{
			return;
		}
		if (globalManager.level.id == "sandbox")
		{
			customtest2 = false;
			if (str_text.text.Length > 0)
			{
				string[] array = str_text.text.Split('\n');
				sandbox_pre = str_text.text;
				sandbox_data = new List<string>();
				for (int i = 0; i < array.Length; i++)
				{
					sandbox_data.Add(array[i]);
				}
				if (array.Length % 2 == 1)
				{
					sandbox_data.Add("");
				}
			}
			NewTestCase();
			ResetProg();
			return;
		}
		if (str_text.text.Length > 0)
		{
			if (str_text.text.IndexOf('\n') != -1)
			{
				str_text.text = str_text.text.Substring(0, str_text.text.IndexOf('\n'));
			}
			isCustomTest = true;
			CustomTestString = str_text.text;
			DisplayCustomIOText(CustomTestString, output_str[0], "#");
			NewTestCase();
		}
		else
		{
			isCustomTest = false;
			customtest2 = false;
			NewTestCase();
			ResetProg();
		}
		customtest2 = false;
		if (isDark)
		{
			str_text.image.color = Color.black;
		}
		else
		{
			str_text.image.color = Color.white;
		}
	}

	public void TryCustomTest()
	{
		str_text.text = "";
		if (globalManager.level.id == "sandbox")
		{
			str_text.text = sandbox_pre;
		}
		customtest2 = true;
		if (isDark)
		{
			str_text.image.color = Color.black;
		}
		else
		{
			str_text.image.color = Color.white;
		}
	}
}
