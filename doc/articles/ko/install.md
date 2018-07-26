# 설치

## NuGet

NuGet 패키지 [x2net](https://www.nuget.org/packages/x2net)은
[패키지 관리자 UI](https://docs.microsoft.com/ko-kr/nuget/tools/package-manager-ui)를 통해,
또는 다음 패키지 관리자 콘솔 명령으로 설치할 수 있습니다.

```
PM> Install-Package x2net
```

xpiler는 x2 정의 파일들을 각각에 대응하는 C# 소스 코드 파일로 변환합니다. 따라서 x2net을
사용한다면 거의 항상 [x2net.xpiler 패키지](https://www.nuget.org/packages/x2net.xpiler)도
함께 설치하게 될 것입니다.

```
PM> Install-Package x2net.xpiler
```

## 소스 코드

[GitHub 저장소](https://github.com/jaykang920/x2net)에서 x2net 소스 코드를 `clone`
하거나 다운로드 받을 수 있습니다.

특정한 태그 버전 소스 코드의 압축된 아카이브 파일들은
[releases](https://github.com/jaykang920/x2net/releases)에서 찾을 수 있습니다.
