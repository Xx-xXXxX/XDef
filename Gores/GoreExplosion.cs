using Microsoft.Xna.Framework;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
namespace XDef.Gores
{
	/// <summary>
	/// 作为Gore的爆炸效果
	/// </summary>
	public class GoreExplosion:ModGore
	{
		public static int[] TimesPerFrame = new int[] { 1, 2, 2, 3, 3, 2, 2 };
		public static int[] TimesTotalPerFrame;
		static GoreExplosion()
		{
			TimesTotalPerFrame = new int[7];
			int t = 0;
			for (int i = 0; i < 7; ++i)
			{
				TimesTotalPerFrame[i] = t;
				t += TimesPerFrame[i];
			}
			Terraria.GameContent.ChildSafety.SafeGore[ModContent.GoreType<GoreExplosion>()] = true;
		}
		public static int TimeMax => TimesTotalPerFrame[6];
		/// <summary>
		/// 生成GoreExplosion
		/// </summary>
		public static Gore NewGoreExplosion(IEntitySource source,Vector2 Pos, float R,Color? color=null) {
			R /= 49;
			Gore gore= Gore.NewGoreDirect(source,Pos, new Vector2(BitOperate.ToFloat((color??Color.White).PackedValue),0),ModContent.GoreType<GoreExplosion>(), R);
			return gore;
		}
#pragma warning disable CS1591 // 缺少对公共可见类型或成员的 XML 注释
		public override void OnSpawn(Gore gore, IEntitySource source)
		{
			gore.numFrames = 7;
			gore.timeLeft = TimeMax;
			gore.frame = 0;
			gore.sticky= false;
			gore.rotation = Main.rand.ToIRandom().NextAngle();
			gore.drawOffset = new Vector2(-49, -49);
		}
		public override bool Update(Gore gore)
		{
			gore.frameCounter += 1;
			if (gore.frameCounter > TimesPerFrame[gore.frame]) {
				gore.frame += 1; gore.frameCounter = 0;
			}
			if (gore.frame >= gore.numFrames) gore.active = false;
			return false;
		}
		public override Color? GetAlpha(Gore gore, Color lightColor)
		{
			return lightColor.MultiplyRGBA(new Color() { PackedValue= BitOperate.ToUInt(gore.velocity.X) });
		}
	}
}
