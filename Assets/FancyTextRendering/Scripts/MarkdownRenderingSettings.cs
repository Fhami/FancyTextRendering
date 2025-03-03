﻿using System;
using TriInspector;
using UnityEngine;

namespace LogicUI.FancyTextRendering
{
    [Serializable]
    public class MarkdownRenderingSettings
    {
        public static MarkdownRenderingSettings Default => new MarkdownRenderingSettings();


        public BoldSettings Bold = new BoldSettings();
        [Serializable] public class BoldSettings
        {
            public bool RenderBold = true;
        }

        public ItalicSettings Italics = new ItalicSettings();
        [Serializable] public class ItalicSettings
        {
            public bool RenderItalics = true;
        }

        public StrikethroughSettings Strikethrough = new StrikethroughSettings();
        [Serializable] public class StrikethroughSettings
        {
            public bool RenderStrikethrough = true;
        }

        public MonospaceSettings Monospace = new MonospaceSettings();
        [Serializable] public class MonospaceSettings
        {
            public bool RenderMonospace = true;

            [Space]
            [ShowIf(nameof(RenderMonospace))]
            public bool UseCustomFont = true;

            private bool CanShowFont => RenderMonospace && UseCustomFont;
            [ShowIf(nameof(CanShowFont))]
            public string FontAssetPathRelativeToResources = "Noto/Noto Mono/NotoMono-Regular";

            [Space]
            [ShowIf(nameof(RenderMonospace))]
            public bool DrawOverlay = true;

            private bool CanShowOverlay => RenderMonospace && DrawOverlay;
            [ShowIf(nameof(CanShowOverlay))]
            public Color OverlayColor = new Color32(0, 0, 0, 60);
            
            [ShowIf(nameof(CanShowOverlay))]
            public float OverlayPaddingPixels = 25;

            [Space]
            [ShowIf(nameof(RenderMonospace))]
            public bool ManuallySetCharacterSpacing = false;

            private bool CanShowCharacterSpacing => RenderMonospace && ManuallySetCharacterSpacing;
            [ShowIf(nameof(CanShowCharacterSpacing))]
            public float CharacterSpacing = 0.69f;

            [Space]
            [ShowIf(nameof(RenderMonospace))]
            public bool AddSeparationSpacing = true;

            private bool CanShowSeparationSpacing => RenderMonospace && AddSeparationSpacing;
            [ShowIf(nameof(CanShowSeparationSpacing))]
            public float SeparationSpacing = 0.3f;
        }


        public ListSettings Lists = new ListSettings();
        [Serializable] public class ListSettings
        {
            public bool RenderUnorderedLists = true;
            public bool RenderOrderedLists = true;

            [Space]
            [ShowIf(nameof(RenderUnorderedLists))]
            public string UnorderedListBullet = "•";

            [ShowIf(nameof(RenderOrderedLists))]
            public string OrderedListNumberSuffix = ".";

            private bool CanShowRenderOrdered => RenderUnorderedLists || RenderOrderedLists;
            [Space]
            [ShowIf(nameof(CanShowRenderOrdered))]
            public float VerticalOffset = 0.76f;

            [ShowIf(nameof(CanShowRenderOrdered))]
            public float BulletOffsetPixels = 100f;

            [ShowIf(nameof(CanShowRenderOrdered))]
            public float ContentSeparationPixels = 20f;
        }

        public LinkSettings Links = new LinkSettings();
        [Serializable] public class LinkSettings
        {
            public bool RenderLinks = true;
            public bool RenderAutoLinks = true;

            private bool CanShowLinkColor => RenderLinks || RenderAutoLinks;
            [ShowIf(nameof(CanShowLinkColor))]
            [ColorUsage(showAlpha: false)]
            public Color LinkColor = new Color32(29, 124, 234, a: byte.MaxValue);
        }

        public HeaderSettings Headers = new HeaderSettings();
        [Serializable] public class HeaderSettings
        {
            public bool RenderPoundSignHeaders = true;
            public bool RenderLineHeaders = true;

            [Space]
            // [ShowIf(nameof(RenderHeaders)), AllowNesting]
            // Can't use ShowIf here yet -- https://github.com/dbrizov/NaughtyAttributes/issues/142
            public HeaderData[] Levels = new HeaderData[]
            {
                new HeaderData(2f, true, true, 0.45f),
                new HeaderData(1.7f, true, true, 0.3f),
                new HeaderData(1.5f, true, false),
                new HeaderData(1.3f, true, false),
            };


            [Serializable]
            public class HeaderData
            {
                public float Size;
                public bool Bold;
                public bool Underline;
                public HeaderCase Case = HeaderCase.None;
                public float VerticalSpacing;


                public HeaderData() { } // Needs a default constructor so it can be deserialized by SUCC
                public HeaderData(float size, bool bold, bool underline, float verticalSpacing = 0)
                {
                    Size = size;
                    Bold = bold;
                    Underline = underline;
                    VerticalSpacing = verticalSpacing;
                }


                public enum HeaderCase
                {
                    None = 0,
                    Uppercase,
                    Smallcaps,
                    Lowercase
                }
            }
        }
        
        public SuperscriptSettings Superscript = new SuperscriptSettings();
        [Serializable] public class SuperscriptSettings
        {
            public bool RenderSuperscript = false;

            [ShowIf(nameof(RenderSuperscript))]
            public bool RenderChainSuperscript = true;
        }
    }
}