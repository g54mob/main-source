using System.Text;
using JetBrains.Annotations;
using UnityConsole;
using UnityEngine;

namespace TH20
{
	[UsedImplicitly(ImplicitUseKindFlags.InstantiatedNoFixedConstructorSignature)]
	public class ToughLuckBalancer : MustCallDestroy
	{
		private float _currentBalance;

		public ToughLuckBalancer()
		{
			ConsoleCommandsDatabase.RegisterCommand("TestToughLuckBalancer", $"Runs 10,000 random samples of the tough luck balancer and runs analysis on the results (default is chanceOfSuccess=0.5 numTests=10000 sensitivity={GameAlgorithms.Config.ToughLuckBalancingSensitivity})", "TestToughLuckBalancer [chanceOfSuccess] [numTests] [sensitivity]", Debug_TestSimulation);
		}

		public override void Destroy()
		{
			ConsoleCommandsDatabase.UnRegisterCommand("TestToughLuckBalancer");
			base.Destroy();
		}

		public bool GetResult(float chanceOfSuccess)
		{
			return GetResultInner(chanceOfSuccess, GameAlgorithms.Config.ToughLuckBalancingSensitivity);
		}

		private bool GetResultInner(float chanceOfSuccess, float sensitivity)
		{
			if (chanceOfSuccess <= 0f)
			{
				return false;
			}
			if (chanceOfSuccess >= 1f)
			{
				return true;
			}
			float num = 1f - chanceOfSuccess;
			float num2 = RandomUtils.GlobalRandomInstance.NextFloat(0f, 1f);
			float num3 = MathUtils.LogisiticFunction(_currentBalance, sensitivity, 0f - num, num);
			if (num2 <= chanceOfSuccess + num3)
			{
				_currentBalance -= num;
				return true;
			}
			_currentBalance += chanceOfSuccess;
			return false;
		}

		private ConsoleCommandResult Debug_TestSimulation(string[] args)
		{
			int result = 10000;
			float result2 = 0.5f;
			float result3 = GameAlgorithms.Config.ToughLuckBalancingSensitivity;
			if (args.Length != 0 && !float.TryParse(args[0], out result2))
			{
				return ConsoleCommandResult.Failed("Couldn't parse floating point argument for chanceOfSuccess!  Should look like this... 0.5");
			}
			if (args.Length > 1 && !int.TryParse(args[1], out result))
			{
				return ConsoleCommandResult.Failed("Couldn't parse integer argument for numTests!");
			}
			if (args.Length > 2 && !float.TryParse(args[2], out result3))
			{
				return ConsoleCommandResult.Failed("Couldn't parse floating point argument for sensitivity!  Should look like this... 1.2");
			}
			float num = 1f - result2;
			float currentBalance = _currentBalance;
			_currentBalance = 0f;
			int num2 = 0;
			int num3 = 0;
			int num4 = 0;
			int num5 = 0;
			float num6 = float.MaxValue;
			float num7 = float.MinValue;
			int num8 = 0;
			int num9 = 0;
			for (int i = 0; i < result; i++)
			{
				bool resultInner = GetResultInner(result2, result3);
				num6 = Mathf.Min(num6, _currentBalance);
				num7 = Mathf.Max(num7, _currentBalance);
				if (resultInner)
				{
					num2++;
					num9++;
					num8 = 0;
					num4 = Mathf.Max(num4, num9);
				}
				else
				{
					num3++;
					num8++;
					num9 = 0;
					num5 = Mathf.Max(num5, num8);
				}
			}
			_currentBalance = currentBalance;
			float num10 = MathUtils.LogisiticFunction(num6, GameAlgorithms.Config.ToughLuckBalancingSensitivity, 0f - num, num);
			float num11 = MathUtils.LogisiticFunction(num7, GameAlgorithms.Config.ToughLuckBalancingSensitivity, 0f - num, num);
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.AppendFormat("Chance of Success = {0:F3}, Sensitivity = {1:F3}", result2, result3).AppendLine();
			stringBuilder.AppendFormat("Successes = {0}, Failures = {1}", num2, num3).AppendLine();
			stringBuilder.AppendFormat("Consecutive Successes = {0}, Consecutive Fails {1}", num4, num5).AppendLine();
			stringBuilder.AppendFormat("Balancer Min = {0}, Balancer Max = {1}", num6, num7).AppendLine();
			stringBuilder.AppendFormat("Adjustment Min = {0:F4}, Adjustment Max = {1:F4}", num10, num11).AppendLine();
			return ConsoleCommandResult.Succeeded(stringBuilder.ToString());
		}
	}
}
