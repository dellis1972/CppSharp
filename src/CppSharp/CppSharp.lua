project "CppSharp"

  kind "ConsoleApp"
  language "C#"
  location "."

  files   { "**.cs" }
  
  links { "System", "System.Core", "Bridge", "Generator" }
