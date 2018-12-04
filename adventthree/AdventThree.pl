#!/usr/bin/perl -w
use Data::Dumper;

my @fabric;
my %overlaps;

while(<>) {
    chomp;
    /#(\d+) @ (\d+),(\d+): (\d+)x(\d+)/;
    for ($i = 0; $i < $4; $i++) {
        for ($j = 0; $j < $5; $j++) {
            $cellref = \$fabric[$2+$i][$3+$i];
            if (!defined $$cellref) {
                $$cellref = $1;
                $nonoverlaps{$1} = 1 if !defined $nonoverlaps{$1};
            } else {
                $nonoverlaps{$$cellref} = 0;
                $nonoverlaps{$1} = 0;
                $$cellref = "X";
            }
        }
    }
}

my $multicount = 0;

foreach my $row (@fabric) {
    foreach my $cell (@$row) {
        next if !defined $cell;
        $multicount++ if $cell =~ /X/;
    }
}

my $free = (grep {$nonoverlaps{$_}} %nonoverlaps)[0];

print "$multicount square inch overlaps.\n";
print "Square $free has no overlaps.\n";
