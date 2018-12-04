#!/usr/bin/perl -w
use Data::Dumper;

my @fabric;

while(<>) {
    chomp;
    /#(\d+) @ (\d+),(\d+): (\d+)x(\d+)/;
    for ($i = 0; $i < $4; $i++) {
        for ($j = 0; $j < $5; $j++) {
            $fabric[$2+$i][$3+$j]++;
        }
    }
}

my $multicount = 0;

foreach my $row (@fabric) {
    foreach my $cell (@$row) {
        next if !defined $cell;
        $multicount++ if $cell > 1;
    }
}

print "$multicount square inch overlaps.\n";
