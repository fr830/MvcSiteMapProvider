﻿// -----------------------------------------------------------------------
// <copyright file="ReflectionSiteMapBuilderFactory.cs" company="">
// TODO: Update copyright text.
// </copyright>
// -----------------------------------------------------------------------

namespace MvcSiteMapProvider.Core.SiteMap.Builder
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using MvcSiteMapProvider.Core.Globalization;

    /// <summary>
    /// TODO: Update summary.
    /// </summary>
    public class ReflectionSiteMapBuilderFactory
        : IReflectionSiteMapBuilderFactory
    {
        public ReflectionSiteMapBuilderFactory(
            INodeKeyGenerator nodeKeyGenerator,
            INodeLocalizer nodeLocalizer,
            IDynamicNodeBuilder dynamicNodeBuilder,
            ISiteMapNodeFactory siteMapNodeFactory
            )
        {
            if (nodeKeyGenerator == null)
                throw new ArgumentNullException("nodeKeyGenerator");
            if (nodeLocalizer == null)
                throw new ArgumentNullException("nodeLocalizer");
            if (dynamicNodeBuilder == null)
                throw new ArgumentNullException("dynamicNodeBuilder");
            if (siteMapNodeFactory == null)
                throw new ArgumentNullException("siteMapNodeFactory");

            this.nodeKeyGenerator = nodeKeyGenerator;
            this.nodeLocalizer = nodeLocalizer;
            this.dynamicNodeBuilder = dynamicNodeBuilder;
            this.siteMapNodeFactory = siteMapNodeFactory;
        }

        protected readonly INodeKeyGenerator nodeKeyGenerator;
        protected readonly INodeLocalizer nodeLocalizer;
        protected readonly IDynamicNodeBuilder dynamicNodeBuilder;
        protected readonly ISiteMapNodeFactory siteMapNodeFactory;


        #region IReflectionSiteMapBuilderFactory Members

        public ISiteMapBuilder Create(IEnumerable<string> includeAssemblies, IEnumerable<string> excludeAssemblies)
        {
            return new ReflectionSiteMapBuilder(
                includeAssemblies, 
                excludeAssemblies, 
                nodeKeyGenerator, 
                nodeLocalizer,
                dynamicNodeBuilder, 
                siteMapNodeFactory);
        }

        #endregion
    }
}
