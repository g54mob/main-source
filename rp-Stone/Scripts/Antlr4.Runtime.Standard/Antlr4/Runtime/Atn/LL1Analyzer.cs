using System.Collections.Generic;
using Antlr4.Runtime.Misc;
using Antlr4.Runtime.Sharpen;

namespace Antlr4.Runtime.Atn
{
	public class LL1Analyzer
	{
		public const int HitPred = 0;

		[NotNull]
		public readonly ATN atn;

		public LL1Analyzer(ATN atn)
		{
			this.atn = atn;
		}

		[return: Nullable]
		public virtual IntervalSet[] GetDecisionLookahead(ATNState s)
		{
			if (s == null)
			{
				return null;
			}
			IntervalSet[] array = new IntervalSet[s.NumberOfTransitions];
			for (int i = 0; i < s.NumberOfTransitions; i++)
			{
				array[i] = new IntervalSet();
				HashSet<ATNConfig> lookBusy = new HashSet<ATNConfig>();
				bool seeThruPreds = false;
				Look(s.Transition(i).target, null, PredictionContext.EMPTY, array[i], lookBusy, new BitSet(), seeThruPreds, addEOF: false);
				if (array[i].Count == 0 || array[i].Contains(0))
				{
					array[i] = null;
				}
			}
			return array;
		}

		[return: NotNull]
		public virtual IntervalSet Look(ATNState s, RuleContext ctx)
		{
			return Look(s, null, ctx);
		}

		[return: NotNull]
		public virtual IntervalSet Look(ATNState s, ATNState stopState, RuleContext ctx)
		{
			IntervalSet intervalSet = new IntervalSet();
			bool seeThruPreds = true;
			PredictionContext ctx2 = ((ctx != null) ? PredictionContext.FromRuleContext(s.atn, ctx) : null);
			Look(s, stopState, ctx2, intervalSet, new HashSet<ATNConfig>(), new BitSet(), seeThruPreds, addEOF: true);
			return intervalSet;
		}

		protected internal virtual void Look(ATNState s, ATNState stopState, PredictionContext ctx, IntervalSet look, HashSet<ATNConfig> lookBusy, BitSet calledRuleStack, bool seeThruPreds, bool addEOF)
		{
			ATNConfig item = new ATNConfig(s, 0, ctx);
			if (!lookBusy.Add(item))
			{
				return;
			}
			if (s == stopState)
			{
				if (ctx == null)
				{
					look.Add(-2);
					return;
				}
				if (ctx.IsEmpty && addEOF)
				{
					look.Add(-1);
					return;
				}
			}
			if (s is RuleStopState)
			{
				if (ctx == null)
				{
					look.Add(-2);
					return;
				}
				if (ctx.IsEmpty && addEOF)
				{
					look.Add(-1);
					return;
				}
				if (ctx != PredictionContext.EMPTY)
				{
					for (int i = 0; i < ctx.Size; i++)
					{
						ATNState aTNState = atn.states[ctx.GetReturnState(i)];
						bool flag = calledRuleStack.Get(aTNState.ruleIndex);
						try
						{
							calledRuleStack.Clear(aTNState.ruleIndex);
							Look(aTNState, stopState, ctx.GetParent(i), look, lookBusy, calledRuleStack, seeThruPreds, addEOF);
						}
						finally
						{
							if (flag)
							{
								calledRuleStack.Set(aTNState.ruleIndex);
							}
						}
					}
					return;
				}
			}
			int numberOfTransitions = s.NumberOfTransitions;
			for (int j = 0; j < numberOfTransitions; j++)
			{
				Transition transition = s.Transition(j);
				if (transition is RuleTransition)
				{
					RuleTransition ruleTransition = (RuleTransition)transition;
					if (!calledRuleStack.Get(ruleTransition.ruleIndex))
					{
						PredictionContext ctx2 = SingletonPredictionContext.Create(ctx, ruleTransition.followState.stateNumber);
						try
						{
							calledRuleStack.Set(ruleTransition.target.ruleIndex);
							Look(transition.target, stopState, ctx2, look, lookBusy, calledRuleStack, seeThruPreds, addEOF);
						}
						finally
						{
							calledRuleStack.Clear(ruleTransition.target.ruleIndex);
						}
					}
					continue;
				}
				if (transition is AbstractPredicateTransition)
				{
					if (seeThruPreds)
					{
						Look(transition.target, stopState, ctx, look, lookBusy, calledRuleStack, seeThruPreds, addEOF);
					}
					else
					{
						look.Add(0);
					}
					continue;
				}
				if (transition.IsEpsilon)
				{
					Look(transition.target, stopState, ctx, look, lookBusy, calledRuleStack, seeThruPreds, addEOF);
					continue;
				}
				if (transition is WildcardTransition)
				{
					look.AddAll(IntervalSet.Of(1, atn.maxTokenType));
					continue;
				}
				IntervalSet intervalSet = transition.Label;
				if (intervalSet != null)
				{
					if (transition is NotSetTransition)
					{
						intervalSet = intervalSet.Complement(IntervalSet.Of(1, atn.maxTokenType));
					}
					look.AddAll(intervalSet);
				}
			}
		}
	}
}
