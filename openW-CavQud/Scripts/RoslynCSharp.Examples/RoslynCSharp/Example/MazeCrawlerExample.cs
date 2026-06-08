using System;
using System.Collections.Generic;
using RoslynCSharp.Compiler;
using UnityEngine;
using UnityEngine.UI;

namespace RoslynCSharp.Example
{
	public class MazeCrawlerExample : MonoBehaviour
	{
		private string activeCSharpSource;

		private ScriptProxy activeCrawlerScript;

		private ScriptDomain domain;

		public InputField runCrawlerInput;

		public Button runCrawlerButton;

		public Button stopCrawlerButton;

		public Button restartCrawlerButton;

		public Button editCodeButton;

		public GameObject codeEditorWindow;

		public Button codeEditorCloseButton;

		public Button codeEditorLoadTemplateButton;

		public Button codeEditorLoadSolutionButton;

		public GameObject mazeMouse;

		public GameObject breadcrumbPrefab;

		public TextAsset mazeCodeTemplate;

		public TextAsset mazeCodeSolution;

		public float mouseSpeed = 5f;

		public bool showCompletedCodeOnStartup;

		public void Awake()
		{
			runCrawlerButton.onClick.AddListener(RunCrawler);
			stopCrawlerButton.onClick.AddListener(StopCrawler);
			restartCrawlerButton.onClick.AddListener(RestartCrawler);
			editCodeButton.onClick.AddListener(delegate
			{
				codeEditorWindow.SetActive(value: true);
			});
			codeEditorCloseButton.onClick.AddListener(delegate
			{
				codeEditorWindow.SetActive(value: false);
			});
			codeEditorLoadTemplateButton.onClick.AddListener(delegate
			{
				runCrawlerInput.text = mazeCodeTemplate.text;
			});
			codeEditorLoadSolutionButton.onClick.AddListener(delegate
			{
				runCrawlerInput.text = mazeCodeSolution.text;
			});
		}

		public void Start()
		{
			domain = ScriptDomain.CreateDomain("MazeCrawlerCode");
			try
			{
				IMetadataReferenceProvider metadataReferenceProvider = AssemblyReference.FromNameOrFile("netstandard");
				if (metadataReferenceProvider.TryResolveReference())
				{
					domain.RoslynCompilerService.ReferenceAssemblies.Add(metadataReferenceProvider);
				}
			}
			catch
			{
			}
			domain.RoslynCompilerService.ReferenceAssemblies.Add(AssemblyReference.FromAssembly(typeof(MazeCrawlerExample).Assembly));
			domain.RoslynCompilerService.ReferenceAssemblies.Add(AssemblyReference.FromAssembly(typeof(UnityEngine.Object).Assembly));
			domain.RoslynCompilerService.ReferenceAssemblies.Add(AssemblyReference.FromAssembly(typeof(Stack<>).Assembly));
			domain.RoslynCompilerService.ReferenceAssemblies.Add(AssemblyReference.FromAssembly(typeof(HashSet<>).Assembly));
			if (showCompletedCodeOnStartup)
			{
				runCrawlerInput.text = mazeCodeSolution.text;
			}
			else
			{
				runCrawlerInput.text = mazeCodeTemplate.text;
			}
		}

		public void RunCrawler()
		{
			string text = runCrawlerInput.text;
			if (activeCSharpSource != text || activeCrawlerScript == null)
			{
				StopCrawler();
				try
				{
					ScriptType scriptType = domain.CompileAndLoadMainSource(text);
					if (scriptType == null)
					{
						if (!domain.RoslynCompilerService.LastCompileResult.Success)
						{
							throw new Exception("Maze crawler code contained errors. Please fix and try again");
						}
						if (!domain.SecurityResult.IsSecurityVerified)
						{
							throw new Exception("Maze crawler code failed code security verification");
						}
						throw new Exception("Maze crawler code does not define a class. You must include one class definition of any name that inherits from 'RoslynCSharp.Example.MazeCrawler'");
					}
					if (!scriptType.IsSubTypeOf<MazeCrawler>())
					{
						throw new Exception("Maze crawler code must define a single type that inherits from 'RoslynCSharp.Example.MazeCrawler'");
					}
					activeCrawlerScript = scriptType.CreateInstance(mazeMouse);
					activeCSharpSource = text;
					activeCrawlerScript.Fields["breadcrumbPrefab"] = breadcrumbPrefab;
					activeCrawlerScript.Fields["moveSpeed"] = mouseSpeed;
					return;
				}
				catch (Exception ex)
				{
					codeEditorWindow.SetActive(value: true);
					throw ex;
				}
			}
			activeCrawlerScript.GetInstanceAs<MazeCrawler>(throwOnError: false).Restart();
		}

		public void StopCrawler()
		{
			if (activeCrawlerScript != null)
			{
				activeCrawlerScript.GetInstanceAs<MazeCrawler>(throwOnError: false).Restart();
				activeCrawlerScript.Dispose();
				activeCrawlerScript = null;
			}
		}

		public void RestartCrawler()
		{
			if (activeCrawlerScript != null)
			{
				ScriptType scriptType = activeCrawlerScript.ScriptType;
				activeCrawlerScript.GetInstanceAs<MazeCrawler>(throwOnError: false).Restart();
				activeCrawlerScript.Dispose();
				activeCrawlerScript = scriptType.CreateInstance(mazeMouse);
				activeCrawlerScript.Fields["breadcrumbPrefab"] = breadcrumbPrefab;
				activeCrawlerScript.Fields["moveSpeed"] = mouseSpeed;
			}
		}
	}
}
