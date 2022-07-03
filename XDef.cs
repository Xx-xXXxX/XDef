using Terraria.Localization;
using Terraria.ModLoader;


namespace XDef
{
#pragma warning disable CS1591 // 缺少对公共可见类型或成员的 XML 注释
    public class XDef : Mod
    {
        private static XDef instance;
        public static XDef Instance => instance;
        public XDef()
        {
            instance = this;
        }
        ~XDef()
        {
        }
        //public static Mod XDebugger;
        //public static Func<NPC, string> XDebuggerDefaultGetNPCDebugData;
        /*
		public override void PostSetupContent()
		{
			XDebugger = ModLoader.GetMod("XDebugger");
			if (XDebugger != null)
			{
				XDebugger.Call("AddGetNPCDebugDataFunc", ModContent.NPCType<Test.NPCs.E3____Hover>(), (Func<NPC, string>)Test.NPCs.E3____Hover.XDebuggerDebugF);
				XDebuggerDefaultGetNPCDebugData = (Func<NPC, string>)XDebugger.Call("GetDefaultNPCDebugDataFunc");
				Log.Debug($"E3____Hover.type:{ModContent.NPCType<Test.NPCs.E3____Hover>()}");
			}
		}*/
        public override void PostSetupContent()
        {
            //XDebugger.XDebugger.PostSetupContent();//XDebuggerDefaultGetNPCDebugData = (Func<NPC, string>)XDebugger.Call("GetDefaultNPCDebugDataFunc");
        }
        public override void Load()
        {
            StaticRefHolder.Load();
            //XDebugger.XDebugger.Load();

            ModTranslation Translations = LocalizationLoader.CreateTranslation(this, "Disabled");
            Translations.SetDefault("Disabled");
            Translations.AddTranslation(GameCulture.FromCultureName( GameCulture.CultureName.Chinese), "已禁用");
            LocalizationLoader.AddTranslation(Translations);

            Translations = LocalizationLoader.CreateTranslation(this, "Enabled");
            Translations.SetDefault("Enabled");
            Translations.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "已启用");
            LocalizationLoader.AddTranslation(Translations);

            Translations = LocalizationLoader.CreateTranslation(this, "On");
            Translations.SetDefault("On");
            Translations.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "开");
            LocalizationLoader.AddTranslation(Translations);
            
            
            Translations = LocalizationLoader.CreateTranslation(this, "Off");
            Translations.SetDefault("Off");
            Translations.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "关");
            LocalizationLoader.AddTranslation(Translations);
        }
        public override void Unload()
        {
            instance = null;
            Logv1 = null;
            UnloadDo.Unload();
            //XDebugger.XDebugger.CloseDebugMode();
            //XDebugger.XDebugger.Unload();
            StaticRefHolder.Unload();
            UnloadDo.Unload();
            SetNPCFallThroughPlatforms.UnLoad();
        }
        public override object Call(params object[] args)
        {
            string CTypeS = (string)args[0];
            object[] Nargs = new object[args.Length - 1];
            for (int i = 1; i < args.Length; i++)
            {
                Nargs[i - 1] = args[i];
            }
            switch (CTypeS)
            {
                default:
                    break;
            }
            return null;
        }
        //      public class XLWA : CtorByF<LogWithUsing> {
        //          public override LogWithUsing F() => new LogWithUsing("XDef");
        //}
        //      public static StaticRef<XLWA> Log;
        private static LogWithUsing logv1;
        public static bool Uselogv1 = false;
        public static LogWithUsing Logv1
        {
            get
            {
                if (logv1 == null) logv1 = new LogWithUsing("XDef", Uselogv1);
                logv1.Using = Uselogv1;
                return logv1;
            }
            set => logv1 = value;
        }
        //public static StaticRefWithFunc<MemoryCheck> mc = new StaticRefWithFunc<MemoryCheck>(()=>new MemoryCheck());
    }
}