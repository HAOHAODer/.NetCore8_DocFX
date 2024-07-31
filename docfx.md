
# 產生 docfx.json
```
docfx metadata
```

# 根據 docfx.json 產生靜態網站
```
docfx build
```

# 本地伺服器來即時預覽生成的文檔，預設端口為 8080。
```
# 本地伺服器來即時預覽生成的文檔，預設端口為 8080。
docfx docfx.json --serve --hostname 0.0.0.0
# 透過指定端口來啟動 DocFX 服務
docfx serve --port 8080 --hostname 0.0.0.0
# 啟用即時監控模式，會自動重新載入變更
docfx serve --watch --hostname 0.0.0.0
# 禁用快取
docfx serve --no-cache --hostname 0.0.0.0
# 指定來源目錄
docfx serve --source _site --hostname 0.0.0.0
```


# 參考
[官方DOC](https://dotnet.github.io/docfx/index.html)
[GitHub]https://github.com/dotnet/docfx
