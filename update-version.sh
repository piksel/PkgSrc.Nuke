#!/usr/bin/env bash

if [[ -z "${GitVersion_Major}" ]]; then
  BASH_BIN="$(which bash)"
  if [[ -n "$MSYSTEM" ]]; then
    echo "Altering bash cygpath: $BASH_BIN"
    BASH_BIN="$(cygpath $BASH_BIN)"
  fi
  gitversion nuke -output buildserver -exec "$BASH_BIN" -execargs "../update-version.sh"
  exit $?
fi

VMAJOR="${GitVersion_Major}"
VMINOR="$(expr ${GitVersion_Patch} + $(expr ${GitVersion_Minor} \* 100))"
VPATCH="0"
BASE_VERSION="$VMAJOR.$VMINOR.$VPATCH"

echo "Upstream version: ${GitVersion_SemVer}"
echo "Package base version: ${BASE_VERSION}"

echo "next-version: $BASE_VERSION" > ../Gitversion.yml